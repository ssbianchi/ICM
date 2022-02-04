using FluentValidation;
using ICM.Domain.Conta.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ICM.Domain.Conta.Rules
{
    public class CNPJValidator : AbstractValidator<CNPJ>
    {
        public CNPJValidator()
        {
            RuleFor(x => x.Valor).Must(CNPJValido).WithMessage("CNPJ Inválido");
        }

        private bool CNPJValido(string valor)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            valor = valor.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (valor.Length != 14)
                return false;

            string tempCnpj = valor.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return valor.EndsWith(digito);
        }
    }
}
