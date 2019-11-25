using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class ComponentsModel
    {

        public int ID { get; set; }

        [Required(ErrorMessage ="Component Type Required")]
        [Display(Name ="Component Type")]
        public int ComponentTypeID { get; set; }

        [Required(ErrorMessage = "Component Name Required")]
        [Display(Name = "Component Name")]
        public string ComponentName { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }
        public string ComponentTypeName { get; set; }
        public SelectList ComponentType { get; set; }
    }
}
