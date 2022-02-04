using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Conta.Dto
{
    public class SocioOutputDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public IList<InfoBasicaOutputDto> InfoBasica { get; set; }
    }

    public class InfoBasicaOutputDto
    {
        public int SocioId { get; set; }
        public string NumTelefone { get; set; }
        public string Email { get; set; }
    }
}
