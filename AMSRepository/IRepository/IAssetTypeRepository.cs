using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IAssetTypeRepository
    {
        AssetTypes CreateAssetType(AssetTypes assetType);
        List<AssetTypes> GetAssetTypes();
        AssetTypes GetAssetTypeByID(int assetTypeID);
        AssetTypes UpdateAssetType(AssetTypes assetType);
    }
}