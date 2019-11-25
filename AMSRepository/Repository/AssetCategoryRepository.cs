using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class AssetCategoryRepository : BaseRepository<AssetCategory>, IAssetCategoryRepository
    {
        public AssetCategory CreateAssetCategory(AssetCategory assetCategory)
        {
            return Insert(assetCategory);
        }

        public AssetCategory UpdateAssetCategory(AssetCategory assetCategory)
        {
            return Update(assetCategory);
        }

        public List<AssetCategory> GetAssetCategories()
        {
            return GetAll();
        }
        public AssetCategory GetAssetCategoryByID(int assetCategoryID)
        {
            return GetByID(assetCategoryID);
        }
    }
}
