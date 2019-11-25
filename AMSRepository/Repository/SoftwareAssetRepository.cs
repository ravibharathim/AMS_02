using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class SoftwareAssetRepository : BaseRepository<SoftwareAssets>,ISoftwareAssetRepository
    {
        public List<SoftwareAssets> GetSoftwareAssets()
        {
            return GetAll();
        }
        public SoftwareAssets CreateSoftwareAsset(SoftwareAssets softwareAsset)
        {
            return Insert(softwareAsset);
        }
        public SoftwareAssets UpdateSoftwareAsset(SoftwareAssets softwareAsset)
        {
            return Update(softwareAsset);
        }
        public SoftwareAssets GetSoftwareAssetByID(int softwareAssetID)
        {
            return GetByID(softwareAssetID);
        }

        public SoftwareAssets GetSoftwareAssetByAssetID(int assetID)
        {
            return context.SoftwareAssets.Where(fet => fet.AssetID == assetID).FirstOrDefault();
        }
    }
}
