using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Conta.Dto
{
    public class SocioInputDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é um campo obrigátorio")]
        public string Nome { get; set; }

        //[Required(ErrorMessage = "CPF é um campo obrigátorio")]
        [StringLength(11, ErrorMessage = "CPF é inválido ou não está em um formato correto")]
        public string CPF { get; set; }

        [StringLength(14, ErrorMessage = "CNPJ é inválido ou não está em um formato correto")]
        public string CNPJ { get; set; }
        public List<InfoBasicaInputDto>  InfoBasicas { get; set; }
    }
    public class InfoBasicaInputDto
    {
        public int SocioId { get; set; }
        public string NumTelefone { get; set; }
        public string Email { get; set; }
    }

    public class HabilitacaoNautica
    {
        public int SocioId { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataValidade { get; set; }
        public int TipoHabilitacao { get; set; }
        public int NumHabilitacao { get; set; }
    }
}
