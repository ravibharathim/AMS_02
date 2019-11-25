using System.Collections.Generic;
using System.Web.Mvc;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public interface IAssetService
    {
        int AssignAsset(AssetModel assetModel);
        int CreateComponent(ComponentsModel component);
        HardwareAssetModel CreateHardwareAsset(HardwareAssetModel hardwareAssetModel);
        SoftwareAssetModel CreateSoftwareAsset(SoftwareAssetModel softwareAssetModel);
        AssetModel GetAssetByID(int Id);
        List<AssetCategoryModel> GetAssetCategories();
        List<AssetModel> GetAssets();
        SelectList GetAssetTypes(int assetCategory, int id = -1);
        List<ComponentsModel> GetComponents();
        List<ComponentTypeModel> GetComponentTypes();

        SoftwareAssetModel EditSoftwareAsset(int assetID);
        int GetLoginEmployeeId();
        void UnassignAsset(AssetModel assetModel);
        int UpdateAsset(AssetModel assetModel);
        HardwareAssetModel UpdateHardwareAsset(HardwareAssetModel hardwareAssetModel);
        SoftwareAssetModel UpdateSoftwareAsset(SoftwareAssetModel softwareAssetModel);
        HardwareAssetModel EditHardwareAsset(int assetID);
        HardwareAssetModel EditCloneHardwareAsset(int assetID);
        SoftwareAssetModel EditCloneSoftwareAsset(int assetID);
        List<ComponentAssetMappingModel> GetComponentAssetMappings(int assetID);
        List<HardwareAssetModel> AutoCompleteForModel(string prefix);
        List<HardwareAssetModel> AutoCompleteForManufacturer(string prefix);
    }
}