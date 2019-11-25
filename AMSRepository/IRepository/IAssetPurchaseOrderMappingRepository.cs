using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IAssetPurchaseOrderMappingRepository
    {
        AssetPurchaseOrderMapping CreateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping);
        AssetPurchaseOrderMapping GetAssetPurchaseOrderMappingByID(int assetPurchaseOrderMappingID);
        List<AssetPurchaseOrderMapping> GetAssetPurchaseOrderMappings();
        AssetPurchaseOrderMapping UpdateAssetPurchaseOrderMapping(AssetPurchaseOrderMapping assetPurchaseOrderMapping);
    }
}