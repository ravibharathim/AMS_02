//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMSRepository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AssetTracker
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public int AssetStatusID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Remarks { get; set; }
    
        public virtual Assets Assets { get; set; }
        public virtual AssetStatus AssetStatus { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
