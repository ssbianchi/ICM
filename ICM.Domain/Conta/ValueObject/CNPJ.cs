using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Conta.ValueObject
{
    public class CNPJ
    {
        public CNPJ()
        {

        }

        public CNPJ(string valor)
        {
            if (valor == null)
                return;
            this.Valor = valor.Replace(".", "").Replace("-", "").Replace("\\", "");
            //this.Valor = valor?.Replace(".", "").Replace("-", "").Replace("\\", "") ?? throw new ArgumentNullException(nameof(CNPJ));
        }

        public string Valor { get; set; }

        public string Formatado => ValorFormatado(this.Valor);

        private string ValorFormatado(string valor)
            => Convert.ToInt64(valor).ToString(@"00\.000\.000\/0000\-00");


    }
}
