using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class AssetTypeModel
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AssetCategoryID { get; set; }
        [Display(Name = "Asset Category")]
        public string AssetCategoryName { get; set; }
        public SelectList AssetCategories { get; set; }
    }
}
