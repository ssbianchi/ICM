using ICM.CrossCutting.Entity;
using ICM.Domain.Embarcacao.Enum;
using ICM.Domain.Titulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Barco
{
    public class Embarcacao : Entity<int>
    {
        public string Nome { get; set; }
        public string RegistroMarinha { get; set; }
        public int Tamanho { get; set; }
        public TipoMotorEnum TipoMotor { get; set; }
        public TipoVagaEnum TipoVaga { get; set; }
        public TipoCombustivelEnum TipoCombustivel { get; set; }

        public IList<TituloSocio> TituloSocio { get; set; }
        public IList<Funcionario.Tripulante> Tripulante { get; set; }
    }
}
