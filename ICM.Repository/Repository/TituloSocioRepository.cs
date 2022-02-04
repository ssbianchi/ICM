using ICM.Domain.Titulo;
using ICM.Domain.Titulo.Repository;
using ICM.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Repository
{
    public class TituloSocioRepository : UnitOfWork<TituloSocio>, ITituloSocioRepository
    {
        public TituloSocioRepository(ICMContext context) : base(context)
        {
        }
    }
}