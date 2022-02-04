using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICM.CrossCutting.Entity;
using ICM.Domain.Conta;
using ICM.Domain.Embarcacao;

namespace ICM.Domain.Titulo
{
    public class TituloSocio : Entity<int>
    {
        public int NumTituloSocio { get; set; }
        public int SocioId { get; set; }
        public int EmbarcacaoId { get; set; }

        public Socio Socio { get; set; }
        public Barco.Embarcacao Embarcacao { get; set; }
    }
}
