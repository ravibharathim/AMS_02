using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface ISoftwareAssetRepository
    {
        SoftwareAssets CreateSoftwareAsset(SoftwareAssets assets);
        SoftwareAssets GetSoftwareAssetByID(int softwareAssetID);
        List<SoftwareAssets> GetSoftwareAssets();
        SoftwareAssets UpdateSoftwareAsset(SoftwareAssets asset);
        SoftwareAssets GetSoftwareAssetByAssetID(int assetID);
    }
}