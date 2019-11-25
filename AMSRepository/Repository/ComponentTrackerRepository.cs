using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class ComponentTrackerRepository : BaseRepository<ComponentTracker>, IComponentTrackerRepository
    {
        public ComponentTracker CreateComponentTracker(ComponentTracker componentTracker)
        {
            return Insert(componentTracker);
        }
        public ComponentTracker UpdateComponentTracker(ComponentTracker componentTracker)
        {
            return Update(componentTracker);
        }
        public List<ComponentTracker> GetComponentTrackers()
        {
            return GetAll();
        }
        public ComponentTracker GetComponentTrackerByID(int componentTrackerID)
        {
            return GetByID(componentTrackerID);
        }
    }
}
