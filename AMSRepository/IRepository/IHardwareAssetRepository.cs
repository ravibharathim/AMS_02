using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IHardwareAssetRepository
    {
        HardwareAssets CreateHardwareAsset(HardwareAssets assets);
        HardwareAssets GetHardwareAssetByID(int hardwareAssetID);
        List<HardwareAssets> GetHardwareAssets();
        HardwareAssets UpdateHardwareAsset(HardwareAssets asset);
        HardwareAssets GetHardwareAssetByAssetID(int assetID);
    }
}