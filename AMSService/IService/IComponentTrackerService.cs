using System.Collections.Generic;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public interface IComponentTrackerService
    {
        int CreateComponentTracker(ComponentTrackerModel componentTrackerModel);
        List<ComponentTrackerModel> GetAssetCategories();
    }
}