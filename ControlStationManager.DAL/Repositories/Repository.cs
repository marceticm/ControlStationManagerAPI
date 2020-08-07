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
                //.Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<TEntity> Get(int id, int userId)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task Remove(int id)
        {
            //Task<TEntity> entity = Context.Set<TEntity>()
            //    .SingleOrDefaultAsync(x => 
            //        (int)x.GetType().GetProperty("Id").GetValue(x, null) == id);

            Task<TEntity> entity = Context.Set<TEntity>()
                .FirstOrDefaultAsync(x => x.Id == id);

            Context.Set<TEntity>().Remove(entity.Result);
            await Context.SaveChangesAsync();
        }

        
    }
}
