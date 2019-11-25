using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMSRepository.Models;
using AMSUtilities.Models;

namespace AMSService.Service
{
  public  interface IComponentAssetMappingService
    {
        ComponentAssetMappingModel AssignComponents(ComponentAssetMappingModel componentAssetMappingModel);
        int CreateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping);
        List<ComponentAssetMappingModel> GetComponentAssetMappings();
        List<ComponentAssetMappingModel> GetComponentAssetMappingsByAssetID(int assetID);
        ComponentAssetMappingModel GetComponentByID(int id);
        ComponentAssetMappingModel GetComponentModel(ComponentAssetMapping componentmapping, System.Web.Mvc.SelectList ddlassets);
        System.Web.Mvc.SelectList GetDropdownAssets(int selectedId = -1);
        ComponentAssetMappingModel UnassignComponents(ComponentAssetMappingModel componentAssetMappingModel);
        int UpdateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping);
    }
}
