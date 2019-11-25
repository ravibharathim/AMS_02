using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AMSUtilities.Enums;

namespace AMSUtilities.Models
{
    public class HardwareAssetModel
    {
        public int ID { get; set; }
        public int AssetCategoryId { get; set; }
        [Required(ErrorMessage = "Please select asset type")]
        [Display(Name = "Asset Type")]
        public int AssetTypeID { get; set; }

        [Display(Name = "Asset Name")]
        [Remote("IsAssetNameExist", "Asset", AdditionalFields = "AssetID", ErrorMessage = "Asset name already exists")]
        public string AssetName { get; set; }
        [Required(ErrorMessage = "Please enter Serial Number")]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public int AssetStatusID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int AssetID { get; set; }
        [Required(ErrorMessage = "Please enter Model")]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please enter Service Tag")]
        [Display(Name = "Service Tag")]
        public string ServiceTag { get; set; }
        [Required(ErrorMessage = "Please enter Manufacturer")]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Please select Warranty Start Date")]
        [Display(Name = "Warranty Start Date")]
        public System.DateTime WarrantyStartDate { get; set; }
        [Required(ErrorMessage = "Please select Warranty End Date")]
        [Display(Name = "Warranty End Date")]
        public System.DateTime WarrantyEndDate { get; set; }
        public string Comment { get; set; }
        //[Required(ErrorMessage = "Please select Invoice")]
        //[Display(Name = "Invoice")]
        public int InvoiceId { get; set; }
        public string componentStyle { get; set; }
        public SelectList AssetCategories { get; set; }
        public SelectList AssetTypes { get; set; }
        public List<ComponentTypeModel> ComponentTypeModels { get; set; }
        public List<ComponentsModel> ComponentsModels{ get; set; }
        public IList<ComponentAssetMappingModel> ComponentAssetMapping { get; set; }

    }
}
