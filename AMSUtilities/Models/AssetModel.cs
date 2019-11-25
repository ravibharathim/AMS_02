using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class AssetModel
    {
        [ScaffoldColumn(false)]
        [Required(ErrorMessage = "AssetID required")]
        public int ID { get; set; }

        [Display(Name="Asset Name")]
        public string AssetName { get; set; }
        public int AssetTypeID { get; set; }

        [Display(Name = "Asset Type")]
        public string AssetType { get; set; }

        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public int AssetStatusID { get; set; }

        [Display(Name = "Asset Status")]
        public string AssetStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        [Display(Name = "Assigned Date")]
        [Required(ErrorMessage = "Assigned Date Required")]
        public DateTime AssignDate { get; set; }

        [Display(Name = "Assign To")]
        [Required(ErrorMessage = "Employee Required")]
        public int EmployeeID { get; set; }

        [Display(Name = "Assigned Employee")]
        public string EmployeeName { get; set; }

        public string Remarks { get; set; }

        public int CategoryID { get; set; }
        public SelectList GetEmployees { get; set; }
        public SelectList AssetCategories { get; set; }
    }
}
