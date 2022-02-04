﻿using FluentValidation;
using ICM.Domain.Conta.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ICM.Domain.Conta.Rules
{
    public class CPFValidator : AbstractValidator<CPF>
    {
        public CPFValidator()
        {
            RuleFor(x => x.Valor).Must(CPFValido).WithMessage("CPF Inválido");
        }

        private bool CPFValido(string valor)
        {
            int[] d = new int[14];
            int[] v = new int[2];
            int j, i, soma;

            if (string.IsNullOrWhiteSpace(valor))
                return false;

            if (valor.Length != 11)
                return false;

            var cpf = Regex.Replace(valor, "[^0-9]", string.Empty);

            //verificando se todos os numeros são iguais
            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            for (i = 0; i <= 10; i++)
                d[i] = Convert.ToInt32(cpf.Substring(i, 1));

            for (i = 0; i <= 1; i++)
            {
                soma = 0;
                for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                v[i] = (soma * 10) % 11;
                if (v[i] == 10) v[i] = 0;
            }

            return (v[0] == d[9] & v[1] == d[10]);
        }
    }

}
