using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ICM.API.Filter
{
    public class HttpExceptionFilter : IActionFilter
    {
        private const string ERROR_CONTENT_TYPE = "application/problem+json";

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                var ex = context.Exception;
                var response = new ValidationProblemDetails(context.ModelState)
                {
                    Status = (int)HttpStatusCode.UnprocessableEntity,
                    Title = ex.Message,
                    Detail = ex.StackTrace,
                };
                context.Result = new ObjectResult(response) { StatusCode = response.Status };
                context.HttpContext.Response.ContentType = ERROR_CONTENT_TYPE;
                context.ExceptionHandled = true;
            }
            else if (context.Result is NotFoundObjectResult)
            {
                var response = new ProblemDetails
                {
                    Status = (int)HttpStatusCode.NotFound,
                    Title = "No result found",
                    Detail = ((NotFoundObjectResult)context.Result).Value?.ToString(),
                };
                context.Result = new ObjectResult(response) { StatusCode = response.Status };
                context.HttpContext.Response.ContentType = ERROR_CONTENT_TYPE;
            }
            else if (context.Result is BadRequestObjectResult)
            {
                var errors = new List<Tuple<string, string>>();
                ProblemDetails response;

                foreach (var ms in context.ModelState)
                    foreach (var error in ms.Value.Errors)
                        errors.Add(new Tuple<string, string>(ms.Key, error.ErrorMessage));

                if (errors.Count == 0)
                {
                    response = new ProblemDetails()
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = "An unexpected internal Error occured",
                        Detail = ((BadRequestObjectResult)context.Result).Value?.ToString() ?? "Unknown error",
                    };
                }
                else
                {
                    var validationResponse = new ValidationProblemDetails()
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = "An unexpected internal Error occured",
                    };
                    foreach (var group in errors.GroupBy(a => a.Item1))
                        validationResponse.Errors.Add(group.Key, group.Select(a => a.Item2).ToArray());

                    response = validationResponse;
                }

                context.Result = new ObjectResult(response) { StatusCode = response.Status };
                context.HttpContext.Response.ContentType = ERROR_CONTENT_TYPE;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}