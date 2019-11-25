using System.Collections.Generic;
using System.Web.Mvc;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public interface IAssetCategoryService
    {
        AssetCategoryModel GetCategoryeModel(int? Id = null);
        int CreateAssetCategory(AssetCategoryModel assetCategoryModel);
        List<AssetCategoryModel> GetAssetCategories();
        int UpdateAssetCategory(AssetCategoryModel assetCategoryModel);
        SelectList GetDropdownAssetCategories(int selectedId = -1);
    }
}