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
    public class SoftwareAssetService : ISoftwareAssetService
    {
        private readonly ISoftwareAssetRepository _softwareAssetRepository;
        public SoftwareAssetService(ISoftwareAssetRepository softwareAssetRepository)
        {
            _softwareAssetRepository = softwareAssetRepository;
        }
        public int CreateSoftwareAsset(SoftwareAssetModel softwareAssetModel)
        {
            SoftwareAssets softwareAsset = null;
            softwareAsset = this._softwareAssetRepository.CreateSoftwareAsset(new SoftwareAssets()
            {
                AssetID = softwareAssetModel.AssetID,
                ProductName = softwareAssetModel.ProductName,
                LicenceNumber = softwareAssetModel.LicenceNumber,
                LicencePurchaseDate = softwareAssetModel.LicencePurchaseDate,
                LicenceExpiryDate = softwareAssetModel.LicenceExpiryDate,
                Comment = softwareAssetModel.Comment
            });

            return softwareAsset.ID;
        }
        public int UpdateSoftwareAsset(SoftwareAssetModel softwareAssetModel)
        {
            SoftwareAssets softwareAsset = _softwareAssetRepository.GetSoftwareAssetByAssetID(softwareAssetModel.AssetID);
            if (softwareAsset != null)
            {
                softwareAsset.AssetID = softwareAssetModel.AssetID;
                softwareAsset.ProductName = softwareAssetModel.ProductName;
                softwareAsset.LicenceNumber = softwareAssetModel.LicenceNumber;
                softwareAsset.LicencePurchaseDate = softwareAssetModel.LicencePurchaseDate;
                softwareAsset.LicenceExpiryDate = softwareAssetModel.LicenceExpiryDate;
                softwareAsset.Comment = softwareAssetModel.Comment;
            }
            _softwareAssetRepository.UpdateSoftwareAsset(softwareAsset);

            return softwareAsset.ID;
        }

        public List<SoftwareAssetModel> GetAssetCategories()
        {
            var softwareAssets = _softwareAssetRepository.GetSoftwareAssets();
            if (softwareAssets != null && softwareAssets.Count > 0)
            {
                return softwareAssets.Select(ac => new SoftwareAssetModel
                {
                    AssetID = ac.AssetID,
                    ProductName = ac.ProductName,
                    LicenceNumber = ac.LicenceNumber,
                    LicencePurchaseDate = ac.LicencePurchaseDate,
                    LicenceExpiryDate = ac.LicenceExpiryDate,
                    Comment = ac.Comment
                }).ToList();
            }
            else
            {
                return new List<SoftwareAssetModel> { };
            }
        }

        public SoftwareAssetModel GetSoftwareAssetByAssetID(int assetID)
        {
            var softwareAsset = _softwareAssetRepository.GetSoftwareAssetByAssetID(assetID);
            if (softwareAsset != null)
            {
                SoftwareAssetModel softwareAssetModel = new SoftwareAssetModel
                {
                    AssetID = softwareAsset.AssetID,
                    ProductName = softwareAsset.ProductName,
                    LicenceNumber = softwareAsset.LicenceNumber,
                    LicencePurchaseDate = softwareAsset.LicencePurchaseDate,
                    LicenceExpiryDate = softwareAsset.LicenceExpiryDate,
                    Comment = softwareAsset.Comment
                };
                return softwareAssetModel;
            }
            else
            {
                return new SoftwareAssetModel { };
            }
        }
    }
}
