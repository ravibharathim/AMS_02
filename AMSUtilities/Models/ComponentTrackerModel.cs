using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSUtilities.Models
{
    public class ComponentTrackerModel
    {
        public int ID { get; set; }
        public int ComponentID { get; set; }
        public int AssetID { get; set; }
        public int ComponentStatusID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Remarks { get; set; }
    }
}
