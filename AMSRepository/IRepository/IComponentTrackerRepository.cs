using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IComponentTrackerRepository
    {
        ComponentTracker CreateComponentTracker(ComponentTracker componentTracker);
        ComponentTracker GetComponentTrackerByID(int componentTrackerID);
        List<ComponentTracker> GetComponentTrackers();
        ComponentTracker UpdateComponentTracker(ComponentTracker componentTracker);
    }
}