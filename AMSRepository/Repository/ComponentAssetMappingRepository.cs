using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class ComponentAssetMappingRepository : BaseRepository<ComponentAssetMapping>, IComponentAssetMappingRepository
    {
        public ComponentAssetMapping CreateComponentAssetMapping(ComponentAssetMapping componentAssetMapping)
        {
            return Insert(componentAssetMapping);
        }

        public ComponentAssetMapping UpdateComponentAssetMapping(ComponentAssetMapping componentAssetMapping)
        {
            return Update(componentAssetMapping);
        }

        public List<ComponentAssetMapping> GetComponentAssetMappings()
        {
            return GetAll();
        }
        public ComponentAssetMapping GetComponentAssetMappingByID(int componentAssetMappingID)
        {
            return GetByID(componentAssetMappingID);
        }

        public List<ComponentAssetMapping> GetComponentAssetMappingsByAssetID(int assetID)
        {
            return context.ComponentAssetMapping.Where(fet => fet.AssignedAssetID == assetID).ToList();
        }
    }
}
