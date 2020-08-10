using ControlStationManager.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlStationManager.DAL.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll(int userId);
        Task<TEntity> Get(int userId, int id);
        Task<TEntity> Add(TEntity entity);
        //Task<TEntity> Update(TEntity entity);
        Task Remove(int id);
    }
}