using System.ComponentModel.DataAnnotations;

namespace AMSUtilities.Models
{
    public class AssetCategoryModel
    {
        public int ID { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comment { get; set; }
    }
}
