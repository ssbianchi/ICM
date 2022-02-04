using ICM.CrossCutting.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Funcionario
{
    public class Tripulante : Entity<int>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int EmbarcacaoId { get; set; }

        public Barco.Embarcacao Embarcacao { get; set; }
    }
}
