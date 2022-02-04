using ICM.Domain.Embarcacao.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Barco.Dto
{
    public class EmbarcacaoOutputDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RegistroMarinha { get; set; }
        public int Tamanho { get; set; }
        public TipoMotorEnum TipoMotor { get; set; }
        public TipoVagaEnum TipoVaga { get; set; }
        public TipoCombustivelEnum TipoCombustivel { get; set; }
    }
}
