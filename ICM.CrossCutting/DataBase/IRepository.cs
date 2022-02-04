﻿using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICM.CrossCutting.DataBase
{
    public interface IRepository<T>
    {
        Task Save(T entity);
        Task SaveRange(IEnumerable<T> entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> Get(object id);
        Task<IEnumerable<T>> GetAll();
        Task<IDbContextTransaction> CreateTransaction();
        Task<IDbContextTransaction> CreateTransaction(System.Data.IsolationLevel isolation = System.Data.IsolationLevel.Serializable);
        Task<IEnumerable<T>> GetAllByCriteria(Expression<Func<T, bool>> expression);
        Task<T> GetOneByCriteria(Expression<Func<T, bool>> expression);
    }
}
