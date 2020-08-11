using ControlStationManager.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAll(int userId)
        {
            return await Context.Set<TEntity>()
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<TEntity> Get(int userId, int id)
        {
            return await Context.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.UserId == userId 
                    && x.Id == id);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Remove(int userId, int id)
        {
            //Task<TEntity> entity = Context.Set<TEntity>()
            //    .SingleOrDefaultAsync(x => 
            //        (int)x.GetType().GetProperty("Id").GetValue(x, null) == id);

            Task<TEntity> entity = Context.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
            if (entity != null)
            {
                Context.Set<TEntity>().Remove(entity.Result);
                await Context.SaveChangesAsync();
                return entity.Result;
            }

            return null;
        }

        
    }
}
