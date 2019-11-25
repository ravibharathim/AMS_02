using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IComponentAssetMappingRepository
    {
        ComponentAssetMapping CreateComponentAssetMapping(ComponentAssetMapping componentAssetMapping);
        ComponentAssetMapping GetComponentAssetMappingByID(int componentAssetMappingID);
        List<ComponentAssetMapping> GetComponentAssetMappings();
        List<ComponentAssetMapping> GetComponentAssetMappingsByAssetID(int assetID);
        ComponentAssetMapping UpdateComponentAssetMapping(ComponentAssetMapping componentAssetMapping);
    }
}