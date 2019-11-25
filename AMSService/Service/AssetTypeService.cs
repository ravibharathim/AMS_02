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
    public class AssetTypeService : IAssetTypeService
    {
        private readonly IAssetTypeRepository _assetAssetTypeRepository;
        private readonly IAssetCategoryService _assetCategoryService;
        public AssetTypeService(IAssetTypeRepository assetAssetTypeRepository, 
            IAssetCategoryService assetCategoryService)
        {
            _assetAssetTypeRepository = assetAssetTypeRepository;
            _assetCategoryService = assetCategoryService;
        }

        public AssetTypeModel GetAssetTypeModel(int? Id = null, int assetCategoryID = -1)
        {
            if (Id.HasValue)
            {
                AssetTypes assetType = _assetAssetTypeRepository.GetAssetTypeByID(Id.Value);
                if (assetType != null)
                {
                    return new AssetTypeModel
                    {
                        ID = assetType.ID,
                        Description = assetType.Description,
                        AssetCategoryID = assetType.AssetCategoryID,
                        AssetCategoryName = assetType.AssetCategory.Description,
                        AssetCategories = _assetCategoryService.GetDropdownAssetCategories(assetType.AssetCategoryID)
                    };
                }
                else
                {
                    throw new EntryPointNotFoundException();
                }
            }
            else
            {
                return new AssetTypeModel { AssetCategories = _assetCategoryService.GetDropdownAssetCategories(assetCategoryID) };
            }
        }
        public int CreateAssetType(AssetTypeModel assetTypeModel)
        {
            AssetTypes assetType = null;
            assetType = this._assetAssetTypeRepository.CreateAssetType(new AssetTypes()
            {
                Description = assetTypeModel.Description,
                AssetCategoryID = assetTypeModel.AssetCategoryID               

            });

            return assetType.ID;
        }

        public int UpdateAssetType(AssetTypeModel assetTypeModel)
        {
            AssetTypes assetType = _assetAssetTypeRepository.GetAssetTypeByID(assetTypeModel.ID);
            if (assetType != null)
            {
                assetType.Description = assetTypeModel.Description;
                assetType.AssetCategoryID = assetTypeModel.AssetCategoryID;
            }
            _assetAssetTypeRepository.UpdateAssetType(assetType);
            return assetType.ID;
        }

        public List<AssetTypeModel> GetAssetTypes()
        {
            var assetTypes = _assetAssetTypeRepository.GetAssetTypes();
            if (assetTypes != null && assetTypes.Count > 0)
            {
                return assetTypes.Select(at => new AssetTypeModel
                {
                    ID = at.ID,
                    Description = at.Description,                    
                    AssetCategoryName = at.AssetCategory.Description
                }).ToList();
            }
            else
            {
                return new List<AssetTypeModel> { };
            }
        }

        public SelectList GetDropdownAssetTypes(int? assetCategoryId,int selectedId = -1)
        {
            List<SelectListItem> assetTypeItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Asset Type", Value = "" } };
            var assetTypes = assetCategoryId.HasValue && assetCategoryId.Value > 0 ? _assetAssetTypeRepository.GetAssetTypes().Where(at=> at.AssetCategoryID == assetCategoryId.Value).ToList(): _assetAssetTypeRepository.GetAssetTypes();
            if (assetTypes != null && assetTypes.Count > 0)
            {
                assetTypes.ForEach(at => {
                    assetTypeItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = at.Description, Value = at.ID.ToString() });
                });
            }

            return new SelectList(assetTypeItems, "Value", "Text");

        }
    }
}
