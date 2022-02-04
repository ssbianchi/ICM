using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.CrossCutting.Exception
{
    public class BusinessException : System.Exception
    {
        public List<BusinessValidation> Errors { get; private set; } = new List<BusinessValidation>();

        public void AddError(BusinessValidation error)
        {
            this.Errors.Add(error);
        }

        public void ValidateAndThrow()
        {
            if (this.Errors.Any())
                throw this;
        }
    }

    public class BusinessValidation
    {
        public string Name { get; set; } = "Erros de Validação";

        public string Message { get; set; }

        public override string ToString()
        {
            return this.Message;
        }
    }
}
