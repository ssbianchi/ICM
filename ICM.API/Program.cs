using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ICM.API.Filter;
using ICM.Application;
using ICM.Repository;

var builder = WebApplication.CreateBuilder(args);
var builderConfig = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers(c => {
    c.Filters.Add(new HttpExceptionFilter());
}).ConfigureApiBehaviorOptions(s =>
{
    s.SuppressModelStateInvalidFilter = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ICM Information API",
        Description = "An ASP.NET Core Web API for accessing ICM Information",
    });
});
//var connection = "Server=tcp:icm-server.database.windows.net,1433;Initial Catalog=ICM_DataBase;Persist Security Info=False;User ID=icm_server;Password=*Abc1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
builder.Services.RegisterRepository(builderConfig["ICMConnection"]);
builder.Services.RegisterApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
