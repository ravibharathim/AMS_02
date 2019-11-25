using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class AssetPurchaseOrderMappingRepository : BaseRepository<AssetPurchaseOrderMapping>, IAssetPurchaseOrderMappingRepository
    {
        public AssetPurchaseOrderMapping CreateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping)
        {
            return Insert(assetPurchaseOrderMapping);
        }

        public AssetPurchaseOrderMapping UpdateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping)
        {
            return Update(assetPurchaseOrderMapping);
        }

        public List<AssetPurchaseOrderMapping> GetAssetPurchaseOrderMappings()
        {
            return GetAll();
        }
        public AssetPurchaseOrderMapping GetAssetPurchaseOrderMappingByID(int assetPurchaseOrderMappingID)
        {
            return GetByID(assetPurchaseOrderMappingID);
        }
    }
}
