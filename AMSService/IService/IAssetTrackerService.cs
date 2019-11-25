using AMSUtilities.Models;

namespace AMSService.Service
{
    public interface IAssetTrackerService
    {
        int CreateAssetTracker(AssetTrackerModel assetTrackerModel);
        System.Collections.Generic.List<AssetTrackerModel> GetAssetCategories();
    }
}