using System.Collections.Generic;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public interface IHardwareAssetService
    {
        int CreateHardwareAsset(HardwareAssetModel hardwareAssetModel);
        List<HardwareAssetModel> GetAssetCategories();
        HardwareAssetModel GetHardwareAssetByAssetID(int assetID);
        int UpdateHardwareAsset(HardwareAssetModel hardwareAssetModel);
    }
}