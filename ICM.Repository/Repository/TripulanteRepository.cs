using ICM.Domain.Funcionario;
using ICM.Domain.Funcionario.Repository;
using ICM.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Repository
{
    public class TripulanteRepository : UnitOfWork<Tripulante>, ITripulanteRepository
    {
        public TripulanteRepository(ICMContext context) : base(context)
        {
        }
    }
}
