using ICM.Domain.Responsavel;
using ICM.Domain.Responsavel.Repository;
using ICM.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Repository
{
    public class DependenteRepository : UnitOfWork<Dependente>, IDependenteRepository
    {
        public DependenteRepository(ICMContext context) : base(context)
        {
        }
    }
}
