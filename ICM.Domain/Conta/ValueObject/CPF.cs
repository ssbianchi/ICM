using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Conta.ValueObject
{
    public class CPF
    {
        public CPF()
        {

        }

        public CPF(string valor)
        {
            if (valor == null)
                return;

            this.Valor = valor?.Replace(".", "").Replace("-", "");
            //this.Valor = valor?.Replace(".", "").Replace("-", "") ?? throw new ArgumentNullException(nameof(CPF));
        }

        public string Valor { get; set; }

        public string Formatado => ValorFormatado(this.Valor);

        private string ValorFormatado(string valor)
            => Convert.ToInt64(valor).ToString(@"000\.000\.000\-00");


    }
}
