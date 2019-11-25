﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AMSEntities : DbContext
    {
        public AMSEntities()
            : base("name=AMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AssetCategory> AssetCategory { get; set; }
        public virtual DbSet<AssetPurchaseOrderMapping> AssetPurchaseOrderMapping { get; set; }
        public virtual DbSet<AssetRequest> AssetRequest { get; set; }
        public virtual DbSet<AssetRequestApprovalHistory> AssetRequestApprovalHistory { get; set; }
        public virtual DbSet<AssetRequestStatus> AssetRequestStatus { get; set; }
        public virtual DbSet<Assets> Assets { get; set; }
        public virtual DbSet<AssetStatus> AssetStatus { get; set; }
        public virtual DbSet<AssetTracker> AssetTracker { get; set; }
        public virtual DbSet<AssetTypes> AssetTypes { get; set; }
        public virtual DbSet<ComponentAssetMapping> ComponentAssetMapping { get; set; }
        public virtual DbSet<Components> Components { get; set; }
        public virtual DbSet<ComponentType> ComponentType { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeAssetMapping> EmployeeAssetMapping { get; set; }
        public virtual DbSet<EmployeeRole> EmployeeRole { get; set; }
        public virtual DbSet<HardwareAssets> HardwareAssets { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseStatus> PurchaseStatus { get; set; }
        public virtual DbSet<Quotation> Quotation { get; set; }
        public virtual DbSet<QuotationStatus> QuotationStatus { get; set; }
        public virtual DbSet<Seats> Seats { get; set; }
        public virtual DbSet<SoftwareAssets> SoftwareAssets { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<ComponentStatus> ComponentStatus { get; set; }
        public virtual DbSet<ComponentTracker> ComponentTracker { get; set; }
    }
}
