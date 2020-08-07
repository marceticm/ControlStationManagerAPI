using ControlStationManager.DAL.Contexts;
using ControlStationManager.DAL.Entities;

namespace ControlStationManager.DAL.Repositories
{
    public class ControlStationRepository : Repository<ControlStation>, IControlStationRepository
    {
        public ControlStationRepository(ControlStationContext context) 
            : base(context)
        {
        }


    }
}
