using ICM.Domain.Conta;
using ICM.Domain.Conta.Repository;
using ICM.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Repository
{
    public class HabilitacaoNauticaRepository : UnitOfWork<HabilitacaoNautica>, IHabilitacaoNauticaRepository
    {
        public HabilitacaoNauticaRepository(ICMContext context) : base(context)
        {
        }
    }
}
