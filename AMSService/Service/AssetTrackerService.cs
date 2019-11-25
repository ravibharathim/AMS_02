using AMSRepository.Models;
using AMSRepository.Repository;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class AssetTrackerService : IAssetTrackerService
    {
        private readonly IAssetTrackerRepository _assetTrackerRepository;
        public AssetTrackerService(IAssetTrackerRepository assetTrackerRepository)
        {
            _assetTrackerRepository = assetTrackerRepository;
        }
        public int CreateAssetTracker(AssetTrackerModel assetTrackerModel)
        {
            AssetTracker assetTracker = null;
            assetTracker = this._assetTrackerRepository.CreateAssetTracker(new AssetTracker()
            {
                AssetID = assetTrackerModel.AssetID,
                EmpID = assetTrackerModel.EmpID,
                AssetStatusID = assetTrackerModel.AssetStatusID,
                CreatedDate = assetTrackerModel.CreatedDate,
                CreatedBy = assetTrackerModel.CreatedBy,
                Remarks = assetTrackerModel.Remarks,
            });
            return assetTracker.ID;
        }
        public List<AssetTrackerModel> GetAssetCategories()
        {
            var assetTrackers = _assetTrackerRepository.GetAssetTrackers();
            if (assetTrackers != null && assetTrackers.Count > 0)
            {
                return assetTrackers.Select(ac => new AssetTrackerModel
                {
                    AssetID = ac.AssetID,
                    EmpID = ac.EmpID,
                    AssetStatusID = ac.AssetStatusID,
                    CreatedDate = ac.CreatedDate,
                    CreatedBy = ac.CreatedBy,
                    Remarks = ac.Remarks,
                }).ToList();
            }
            else
            {
                return new List<AssetTrackerModel> { };
            }
        }
    }
}
