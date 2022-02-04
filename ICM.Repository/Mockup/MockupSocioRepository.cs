using ICM.Domain.Conta;
using ICM.Domain.Conta.Repository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Mockup
{
    public class MockupSocioRepository : ISocioRepository
    {
        public async Task<IDbContextTransaction> CreateTransaction()
        {
            return null;
        }

        public async Task<IDbContextTransaction> CreateTransaction(IsolationLevel isolation = IsolationLevel.Serializable)
        {
            return null;
        }

        public async Task Delete(Socio entity)
        {
            
        }

        public async Task<Socio> Get(object id)
        {
            return new Socio()
            {
                Id = 1,
                Nome = "Sergio Bianchi",
                CPF = new Domain.Conta.ValueObject.CPF() { Valor = "," },
                InfoBasica = new List<InfoBasica>()
                {

                },
                HabilitacaoNautica = new List<HabilitacaoNautica>()
                {

                },
            };
        }

        public Task<IEnumerable<Socio>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Socio>> GetAllByCriteria(Expression<Func<Socio, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Socio> GetOneByCriteria(Expression<Func<Socio, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Save(Socio entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveRange(IEnumerable<Socio> entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Socio entity)
        {
            throw new NotImplementedException();
        }
    }
}
