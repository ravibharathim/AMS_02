using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IAssetRepository
    {
        Assets CreateAsset(Assets asset);
        List<Assets> GetAssets();
        Assets GetAssetByID(int assetID);
        Assets UpdateAsset(Assets asset);
    }
}