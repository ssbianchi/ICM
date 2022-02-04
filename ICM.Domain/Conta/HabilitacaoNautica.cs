using ICM.CrossCutting.Entity;
using ICM.Domain.Conta.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Conta
{
    public class HabilitacaoNautica : Entity<int>
    {
        public int SocioId { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataValidade { get ; set; }
        public TipoHabilitacaoEnum TipoHabilitacao { get; set; }
        public int NumHabilitacao { get; set; }

        public Socio Socio { get; set; }
    }
}
