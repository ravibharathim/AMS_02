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
    public class AssetCategoryService : IAssetCategoryService
    {
        private readonly IAssetCategoryRepository _assetCategoryRepository;
        public AssetCategoryService(IAssetCategoryRepository assetCategoryRepository)
        {
            _assetCategoryRepository = assetCategoryRepository;
        }
        public AssetCategoryModel GetCategoryeModel(int? Id = null)
        {
            if (Id.HasValue)
            {
                AssetCategory assetCategory = _assetCategoryRepository.GetAssetCategoryByID(Id.Value);
                if (assetCategory != null)
                {
                    return new AssetCategoryModel
                    {
                        ID = assetCategory.ID,
                        Description = assetCategory.Description,
                        Comment = assetCategory.Comment
                    };
                }
                else
                {
                    throw new EntryPointNotFoundException();
                }
            }
            else
            {
                return new AssetCategoryModel { };
            }
        }
        public int CreateAssetCategory(AssetCategoryModel assetCategoryModel)
        {
            AssetCategory assetCategory = null;
            assetCategory = this._assetCategoryRepository.CreateAssetCategory(new AssetCategory()
            {
                Description = assetCategoryModel.Description,
                Comment = assetCategoryModel.Comment
            });

            return assetCategory.ID;
        }

        public int UpdateAssetCategory(AssetCategoryModel assetCategoryModel)
        {
            AssetCategory assetCategory = _assetCategoryRepository.GetAssetCategoryByID(assetCategoryModel.ID);
            if (assetCategory != null)
            {
                assetCategory.Description = assetCategoryModel.Description;
                assetCategory.Comment = assetCategoryModel.Comment;
            }

            _assetCategoryRepository.UpdateAssetCategory(assetCategory);

            return assetCategory.ID;
        }

        public List<AssetCategoryModel> GetAssetCategories()
        {
            var assetCategories = _assetCategoryRepository.GetAssetCategories();
            if (assetCategories != null && assetCategories.Count > 0)
            {
                return assetCategories.Select(ac => new AssetCategoryModel
                {
                    ID = ac.ID,
                    Description = ac.Description,
                    Comment = ac.Comment
                }).ToList();
            }
            else
            {
                return new List<AssetCategoryModel> { };
            }
        }

        public SelectList GetDropdownAssetCategories(int selectedId = -1)
        {
            List<SelectListItem> assetCategoryItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Asset Category", Value = "" } };
            var assetCategories = _assetCategoryRepository.GetAssetCategories();
            if (assetCategories != null && assetCategories.Count > 0)
            {
                assetCategories.ForEach(at => {
                    assetCategoryItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = at.Description, Value = at.ID.ToString() });
                });
            }

            return new SelectList(assetCategoryItems, "Value", "Text", selectedId);

        }
    }
}
