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
    
    public partial class Components
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Components()
        {
            this.ComponentAssetMapping = new HashSet<ComponentAssetMapping>();
        }
    
        public int ID { get; set; }
        public int ComponentTypeID { get; set; }
        public string ComponentName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ComponentAssetMapping> ComponentAssetMapping { get; set; }
        public virtual ComponentType ComponentType { get; set; }
    }
}
