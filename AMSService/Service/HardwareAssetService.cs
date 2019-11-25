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
    public class HardwareAssetService : IHardwareAssetService
    {
        private readonly IHardwareAssetRepository _hardwareAssetRepository;
        public HardwareAssetService(IHardwareAssetRepository hardwareAssetRepository)
        {
            _hardwareAssetRepository = hardwareAssetRepository;
        }
        public int CreateHardwareAsset(HardwareAssetModel hardwareAssetModel)
        {
            HardwareAssets hardwareAsset = null;
            hardwareAsset = this._hardwareAssetRepository.CreateHardwareAsset(new HardwareAssets()
            {
                AssetID = hardwareAssetModel.AssetID,
                Model = hardwareAssetModel.Model,
                ServiceTag = hardwareAssetModel.ServiceTag,
                Manufacturer = hardwareAssetModel.Manufacturer,
                WarrantyStartDate = hardwareAssetModel.WarrantyStartDate,
                WarrantyEndDate = hardwareAssetModel.WarrantyEndDate,
                Comment = hardwareAssetModel.Comment
            });

            return hardwareAsset.ID;
        }
        public int UpdateHardwareAsset(HardwareAssetModel hardwareAssetModel)
        {
            HardwareAssets hardwareAsset = _hardwareAssetRepository.GetHardwareAssetByAssetID(hardwareAssetModel.AssetID);
            if (hardwareAsset != null)
            {
                hardwareAsset.AssetID = hardwareAssetModel.AssetID;
                hardwareAsset.Model = hardwareAssetModel.Model;
                hardwareAsset.ServiceTag = hardwareAssetModel.ServiceTag;
                hardwareAsset.Manufacturer = hardwareAssetModel.Manufacturer;
                hardwareAsset.WarrantyStartDate = hardwareAssetModel.WarrantyStartDate;
                hardwareAsset.WarrantyEndDate = hardwareAssetModel.WarrantyEndDate;
                hardwareAsset.Comment = hardwareAssetModel.Comment;
            }
            _hardwareAssetRepository.UpdateHardwareAsset(hardwareAsset);

            return hardwareAsset.ID;
        }

        public List<HardwareAssetModel> GetAssetCategories()
        {
            var hardwareAssets = _hardwareAssetRepository.GetHardwareAssets();
            if (hardwareAssets != null && hardwareAssets.Count > 0)
            {
                return hardwareAssets.Select(ac => new HardwareAssetModel
                {
                    AssetID = ac.AssetID,
                    Model = ac.Model,
                    ServiceTag = ac.ServiceTag,
                    Manufacturer = ac.Manufacturer,
                    WarrantyStartDate = ac.WarrantyStartDate,
                    WarrantyEndDate = ac.WarrantyEndDate,
                    Comment = ac.Comment
                }).ToList();
            }
            else
            {
                return new List<HardwareAssetModel> { };
            }
        }

        public HardwareAssetModel GetHardwareAssetByAssetID(int assetID)
        {
            var hardwareAsset = _hardwareAssetRepository.GetHardwareAssetByAssetID(assetID);
            if (hardwareAsset != null)
            {
                HardwareAssetModel harwareAssetModel = new HardwareAssetModel
                {
                     Model = hardwareAsset.Model,
                     ServiceTag = hardwareAsset.ServiceTag,
                     Manufacturer = hardwareAsset.Manufacturer,
                     WarrantyStartDate = hardwareAsset.WarrantyStartDate,
                     WarrantyEndDate = hardwareAsset.WarrantyEndDate,
                     Comment = hardwareAsset.Comment
                };
                return harwareAssetModel;
            }
            else
            {
                return new HardwareAssetModel { };
            }
        }
    }
}
