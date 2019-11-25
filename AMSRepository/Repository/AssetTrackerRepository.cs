using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class AssetTrackerRepository : BaseRepository<AssetTracker>, IAssetTrackerRepository
    {
        public AssetTracker CreateAssetTracker(AssetTracker assetTracker)
        {
            return Insert(assetTracker);
        }
        public AssetTracker UpdateAssetTracker(AssetTracker assetTracker)
        {
            return Update(assetTracker);
        }
        public List<AssetTracker> GetAssetTrackers()
        {
            return GetAll();
        }
        public AssetTracker GetAssetTrackerByID(int assetTrackerID)
        {
            return GetByID(assetTrackerID);
        }
    }
}
