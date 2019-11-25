using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class SoftwareAssetModel
    {
        public int ID { get; set; }
        public int AssetCategoryId { get; set; }
        [Required(ErrorMessage = "Please select asset type")]
        [Display(Name = "Asset Type")]
        public int AssetTypeID { get; set; }
        [Required(ErrorMessage = "Please enter Asset Name")]
        [Display(Name = "Asset Name")]
        [Remote("IsAssetNameExist", "Asset", AdditionalFields = "AssetID", ErrorMessage = "Asset name already exists")]
        public string AssetName { get; set; }
        [Required(ErrorMessage = "Please enter Serial Number")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public int AssetStatusID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int AssetID { get; set; }
        [Required(ErrorMessage = "Please enter Product Name")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter Licence Number")]
        [Display(Name = "Licence Number")]
        public string LicenceNumber { get; set; }
        [Required(ErrorMessage = "Please enter Licence Purchase Date")]
        [Display(Name = "Licence Purchase Date")]
        public DateTime LicencePurchaseDate { get; set; }
        [Required(ErrorMessage = "Please enter Licence Expiry Date")]
        [Display(Name = "Licence Expiry Date")]
        public DateTime LicenceExpiryDate { get; set; }
        public string Comment { get; set; }
        public int InvoiceId { get; set; }
        public string componentStyle { get; set; }
        public SelectList AssetCategories { get; set; }
        public SelectList AssetTypes { get; set; }
        public List<ComponentTypeModel> ComponentTypeModels { get; set; }
        public List<ComponentsModel> ComponentsModels { get; set; }
        public IList<ComponentAssetMappingModel> ComponentAssetMapping { get; set; }
    }
}
