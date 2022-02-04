using ICM.Domain.Conta;
using ICM.Domain.Conta.Repository;
using ICM.Repository.Context;

namespace ICM.Repository.Repository
{
    public class SocioRepository : UnitOfWork<Socio>, ISocioRepository
    {
        public SocioRepository(ICMContext context) : base(context)
        {
        }
    }
}
