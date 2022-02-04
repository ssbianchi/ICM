using ICM.Domain.Barco;
using ICM.Domain.Barco.Repository;
using ICM.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Repository
{
    public class EmbarcacaoRepository : UnitOfWork<Embarcacao>, IEmbarcacaoRepository
    {
        public EmbarcacaoRepository(ICMContext context) : base(context)
        {
        }
    }
}
