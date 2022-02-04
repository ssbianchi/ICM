using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Conta.Rules
{
    public class SocioValidator: AbstractValidator<Socio>
    {
        public SocioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.CPF).SetValidator(new CPFValidator());
            RuleFor(x => x.CNPJ).SetValidator(new CNPJValidator());
        }

    }
}
