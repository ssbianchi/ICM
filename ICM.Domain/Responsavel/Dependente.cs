using ICM.CrossCutting.Entity;
using ICM.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Responsavel
{
    public class Dependente : Entity<int>
    {
        public int SocioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public Socio Socio { get; set; }
    }
}
