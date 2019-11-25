using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSUtilities.Models
{
   public class AssetTrackerModel
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int? EmpID { get; set; }
        public int AssetStatusID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Remarks { get; set; }
    }
}
