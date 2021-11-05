using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DALContext context;

        public UnitOfWork(DALContext _context)
        {
            this.context = _context;
        }
        public Task<int> DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                context.Set<TEntity>().Attach(entity);
                context.Set<TEntity>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(int id) where TEntity : class
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public Task<int> InsertAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                context.Set<TEntity>().Add(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            var dbEntityEntry = context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                context.Set<TEntity>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            return Task.FromResult(1);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await context.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
