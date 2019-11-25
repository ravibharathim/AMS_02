using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class ComponentTypeModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AssetTypeID { get; set; }
        public SelectList AssetTypes { get; set; }
        [Required]
        public int AssetCategoryId { get; set; }
        public SelectList AssetCategories { get; set; }
        public string AssetCategoryName { get; set; }
        public string AssetTypeName { get; set; }
        [Required]
        [Display(Name="Active")]
        public bool IsActive { get; set; }
        public bool? Mandatory { get; set; }
        public SelectList AssetType { get; set; }


    }
}


