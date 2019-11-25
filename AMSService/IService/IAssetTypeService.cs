using System.Collections.Generic;
using System.Web.Mvc;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public interface IAssetTypeService
    {
        AssetTypeModel GetAssetTypeModel(int? Id = null, int assetCategoryID =-1);
        int CreateAssetType(AssetTypeModel assetTypeModel);
        List<AssetTypeModel> GetAssetTypes();
        int UpdateAssetType(AssetTypeModel assetTypeModel);
        SelectList GetDropdownAssetTypes(int? assetCategoryId, int selectedId = -1);
    }
}