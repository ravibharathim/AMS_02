using System;

using Unity;
using Unity.log4net;
using AMSService.Service;
using AMSRepository.Repository;

namespace NLTDAMS
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.AddNewExtension<Log4NetExtension>();

            //Register Services 
            container.RegisterType<IAssetService, AssetService>();
            container.RegisterType<IAssetTrackerService, AssetTrackerService>();
            container.RegisterType<IAssetCategoryService, AssetCategoryService>();
            container.RegisterType<IAssetTypeService, AssetTypeService>();
            container.RegisterType<IHardwareAssetService, HardwareAssetService>();
            container.RegisterType<ISoftwareAssetService, SoftwareAssetService>();
            container.RegisterType<IEmployeeAssetMappingService, EmployeeAssetMappingService>();
            container.RegisterType<IComponentAssetMappingService, ComponentAssetMappingService>();
            container.RegisterType<IComponentTypeService, ComponentTypeService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IVendorService, VendorService>();
            container.RegisterType<IComponentsService, ComponentsService>();
            container.RegisterType<IComponentTrackerService, ComponentTrackerService>();
            container.RegisterType<IQuotationService, QuotationService>();
            //Register Repository 
            container.RegisterType<IAssetRepository, AssetRepository>();
            container.RegisterType<IAssetTrackerRepository, AssetTrackerRepository>();
            container.RegisterType<IAssetCategoryRepository, AssetCategoryRepository>();
            container.RegisterType<IAssetTypeRepository, AssetTypeRepository>();
            container.RegisterType<IAssetPurchaseOrderMappingRepository, AssetPurchaseOrderMappingRepository>();
            container.RegisterType<IHardwareAssetRepository, HardwareAssetRepository>();
            container.RegisterType<ISoftwareAssetRepository, SoftwareAssetRepository>();
            container.RegisterType <IComponentAssetMappingRepository,ComponentAssetMappingRepository>();
            container.RegisterType<IComponentTypeRepository, ComponentTypeRepository>();
            container.RegisterType<IComponentsRepository, ComponentsRepository>();
            container.RegisterType<IEmployeeAssetMappingRepository, EmployeeAssetMappingRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployeeRoleRepository, EmployeeRoleRepository>();
            container.RegisterType<ILocationRepository, LocationRepository>();
            container.RegisterType<ISeatsRepository, SeatsRepository>(); 
            container.RegisterType<IPurchaseOrderRepository, PurchaseOrderRepository>();
            container.RegisterType<IPurchaseStatusRepository, PurchaseStatusRepository>();
            container.RegisterType<IQuotationRepository, QuotationRepository>();
            container.RegisterType<IQuotationStatusRepository, QuotationStatusRepository>();
            container.RegisterType<IVendorRepository, VendorRepository>();
            container.RegisterType<IComponentTrackerRepository, ComponentTrackerRepository>();
        }
    }
}