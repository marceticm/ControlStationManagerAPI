using ControlStationManager.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll(int userId);
        Task<TEntity> Get(int id, int userId);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(int id);
    }
}