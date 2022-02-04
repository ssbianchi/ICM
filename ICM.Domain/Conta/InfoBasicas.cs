using ICM.CrossCutting.Entity;
using ICM.Domain.Conta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Domain.Conta
{
    public class InfoBasica : Entity<int>
    {
        public int SocioId { get; set; }
        public string NumTelefone { get; set; }
        public string Email { get; set; }

        public Socio Socio { get; set; }
    }
}
