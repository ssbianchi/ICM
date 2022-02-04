﻿using ICM.CrossCutting.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Repository.Context
{
    public class UnitOfWork<T> : IRepository<T> where T : class
    {
        public DbSet<T> Query { get; set; }
        public DbContext Context { get; set; }

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
            this.Query = context.Set<T>();
        }

        public async Task<IDbContextTransaction> CreateTransaction()
        {
            return await this.Context.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> CreateTransaction(System.Data.IsolationLevel isolation = System.Data.IsolationLevel.Serializable)
        {
            return await this.Context.Database.BeginTransactionAsync(isolation);
        }

        public async Task Delete(T entity)
        {
            this.Query.Remove(entity);
            await this.Context.SaveChangesAsync();

        }

        public async Task Save(T entity)
        {
            await this.Query.AddAsync(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task SaveRange(IEnumerable<T> entities)
        {
            await this.Query.AddRangeAsync(entities);
            await this.Context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            this.Query.Update(entity);
            await this.Context.SaveChangesAsync();
        }

        public async Task<T> Get(object id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllByCriteria(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(this.Query.Where(expression).AsEnumerable());
        }

        public async Task<T> GetOneByCriteria(Expression<Func<T, bool>> expression)
        {
            return await this.Query.Where(expression).FirstOrDefaultAsync();
        }

    }
}
