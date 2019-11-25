using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AMSUtilities.Models
{
    public class QuotationModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Vendor is Required")]
        public int VendorID { get; set; }
        public int AssetRequestID { get; set; }

        [Display(Name = "Quotation")]
        public string QuotationFilePath { get; set; }

        [Required(ErrorMessage = "Quotation Status is Required")]
        public int QuotationStatusID { get; set; }

        [Display(Name = "Received Date")]
        [Required(ErrorMessage = "Quotation Received Date is Required")]
        public DateTime? QuotationReceivedDate { get; set; }

        [Display(Name ="Vendor")]
        public string VendorName { get; set; }

        [Display(Name = "Quotation Status")]
        public string QuotationStatus { get; set; }

        public SelectList Vendorddl { get; set; }

        [Required(ErrorMessage = "Quotation is Required")]
       // [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.pdf)$", ErrorMessage = "Only PDF files allowed.")]
        public HttpPostedFileBase QuotationFile { get; set; }
    }
}
