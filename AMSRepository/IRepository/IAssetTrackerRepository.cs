using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IAssetTrackerRepository
    {
        AssetTracker CreateAssetTracker(AssetTracker assetTracker);
        AssetTracker GetAssetTrackerByID(int assetTrackerID);
        List<AssetTracker> GetAssetTrackers();
        AssetTracker UpdateAssetTracker(AssetTracker assetTracker);
    }
}