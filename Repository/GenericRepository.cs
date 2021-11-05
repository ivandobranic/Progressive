using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
      where TEntity : class
    {

        private readonly DALContext Context;
        private DbSet<TEntity> Entities;
        public GenericRepository(DALContext context)
        {
            this.Context = context;
            Entities = Context.Set<TEntity>();

        }


        public IQueryable<TEntity> Get()
        {
            return Entities;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {

            return await Entities.FindAsync(id);

        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentException("entity");
                }
                Entities.Add(entity);
                return await Context.SaveChangesAsync();

            }
            catch (DbUpdateException dbEx)
            {
                throw dbEx;
            }

        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentException("entity");
                }
                Context.Entry(entity).State = EntityState.Modified;
                return await Context.SaveChangesAsync();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            try
            {
                var entity = await Entities.FindAsync(id);
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Context.Entry(entity).State = EntityState.Deleted;
                return await Context.SaveChangesAsync();
            }
            catch (Exception dbEx)
            {
                throw dbEx;
            }
        }
    }
}
