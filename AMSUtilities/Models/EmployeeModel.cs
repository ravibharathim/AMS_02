using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSUtilities.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int EmployeeRoleID { get; set; }
        public string EmployeeName { get; set; }
        public int SeatID { get; set; }
        public string MailID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public bool ISActive { get; set; }
        public int? ManagerID { get; set; }
        public string CorpId { get; set; }
    }
}
