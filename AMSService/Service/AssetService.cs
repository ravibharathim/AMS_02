using AMSRepository.Models;
using AMSRepository.Repository;
using AMSService.Service;
using AMSUtilities.Enums;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class AssetService : IAssetService
    {
        IAssetRepository _assetRepository;
        IAssetTypeService _assetTypeService;
        IAssetCategoryService _assetCategoryService;
        IHardwareAssetService _hardwareAssetService;
        ISoftwareAssetService _softwareAssetService;
        IAssetTrackerService _assetTrackerService;
        IEmployeeService _employeeService;
        IComponentTypeService _componentTypeService;
        IComponentsService _componentsService;
        IComponentAssetMappingService _componentAssetMappingService;
        IEmployeeAssetMappingRepository _employeeAssetMappingRepository;
        IComponentTrackerService _componentTrackerService;
        public AssetService(IAssetCategoryService assetCategoryService
            , IAssetTypeService assetTypeService
            , IAssetRepository assetRepository
            , IHardwareAssetService hardwareAssetService
            , ISoftwareAssetService softwareAssetService
            , IAssetTrackerService assetTrackerService
            , IEmployeeService employeeService
            , IComponentTypeService componentTypeService
            , IComponentsService componentsService
            , IComponentAssetMappingService componentAssetMappingService
            , IEmployeeAssetMappingRepository employeeAssetMappingRepository
            , IComponentTrackerService componentTrackerService)
        {
            _assetCategoryService = assetCategoryService;
            _assetTypeService = assetTypeService;
            _assetRepository = assetRepository;
            _hardwareAssetService = hardwareAssetService;
            _softwareAssetService = softwareAssetService;
            _assetTrackerService = assetTrackerService;
            _employeeService = employeeService;
            _componentTypeService = componentTypeService;
            _componentsService = componentsService;
            _componentAssetMappingService = componentAssetMappingService;
            _employeeAssetMappingRepository = employeeAssetMappingRepository;
            _componentTrackerService = componentTrackerService;
        }
        public List<AssetCategoryModel> GetAssetCategories()
        {
            var assetCategoryList = _assetCategoryService.GetAssetCategories();
            return assetCategoryList;
        }
        public SelectList GetAssetTypes(int assetCategory, int id = -1)
        {
            var assetTypes = _assetTypeService.GetDropdownAssetTypes(assetCategory, id);
            return assetTypes;
        }
        public HardwareAssetModel CreateHardwareAsset(HardwareAssetModel hardwareAssetModel)
        {
            Assets assets = new Assets
            {
                AssetName = hardwareAssetModel.AssetName,
                SerialNumber = hardwareAssetModel.SerialNumber,
                AssetTypeID = hardwareAssetModel.AssetTypeID,
                AssetStatusID = (int)AssetTrackingStatus.New,
                CreatedDate = DateTime.Now,
                CreatedBy = GetLoginEmployeeId()
            };
            var createdAsset = _assetRepository.CreateAsset(assets);

            hardwareAssetModel.AssetID = createdAsset.ID;
            _hardwareAssetService.CreateHardwareAsset(hardwareAssetModel);

            AssetTrackerModel assetTrackerModel = new AssetTrackerModel
            {
                AssetID = hardwareAssetModel.AssetID,
                AssetStatusID = (int)AssetTrackingStatus.New,
                CreatedDate = DateTime.Now,
                CreatedBy = assets.CreatedBy,
                Remarks = hardwareAssetModel.Comment,
            };
            _assetTrackerService.CreateAssetTracker(assetTrackerModel);

            if (hardwareAssetModel.ComponentAssetMapping != null)
            {
                if (hardwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory == true || fet.ComponentID != 0).ToList().Count > 0)
                {
                    foreach (var item in hardwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory == true || fet.ComponentID != 0).ToList())
                    {
                        item.AssignedAssetID = createdAsset.ID;
                        item.ActualAssetID = createdAsset.ID;
                        item.AssignedDate = DateTime.Now;
                        item.AssignedBy = GetLoginEmployeeId();
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = GetLoginEmployeeId();
                        item.ComponentStatusId = (int)ComponentTrackingStatus.Assign;
                        _componentAssetMappingService.CreateComponentAssetMapping(item);
                        ComponentTrackerModel componentTrackerModel = new ComponentTrackerModel
                        {
                            AssetID = createdAsset.ID,
                            ComponentID = item.ComponentID,
                            ComponentStatusID = (int)ComponentTrackingStatus.Assign,
                            CreatedBy = GetLoginEmployeeId(),
                            CreatedDate = DateTime.Now
                        };
                        _componentTrackerService.CreateComponentTracker(componentTrackerModel);
                    }
                }
            }
            return hardwareAssetModel;
        }
        public SoftwareAssetModel CreateSoftwareAsset(SoftwareAssetModel softwareAssetModel)
        {
            Assets assets = new Assets
            {
                AssetName = softwareAssetModel.AssetName,
                SerialNumber = softwareAssetModel.SerialNumber,
                AssetTypeID = softwareAssetModel.AssetTypeID,
                AssetStatusID = (int)AssetTrackingStatus.New,
                CreatedDate = DateTime.Now,
                CreatedBy = GetLoginEmployeeId()
            };
            var createdAsset = _assetRepository.CreateAsset(assets);
            softwareAssetModel.AssetID = createdAsset.ID;
            _softwareAssetService.CreateSoftwareAsset(softwareAssetModel);

            AssetTrackerModel assetTrackerModel = new AssetTrackerModel
            {
                AssetID = softwareAssetModel.AssetID,
                AssetStatusID = (int)AssetTrackingStatus.New,
                CreatedDate = DateTime.Now,
                CreatedBy = assets.CreatedBy,
                Remarks = softwareAssetModel.Comment,
            };
            _assetTrackerService.CreateAssetTracker(assetTrackerModel);
            if (softwareAssetModel.ComponentAssetMapping != null)
            {
                if (softwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory == true || fet.ComponentID != 0).ToList().Count > 0)
                {
                    foreach (var item in softwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory == true || fet.ComponentID != 0).ToList())
                    {
                        item.AssignedAssetID = createdAsset.ID;
                        item.ActualAssetID = createdAsset.ID;
                        item.AssignedDate = DateTime.Now;
                        item.AssignedBy = GetLoginEmployeeId();
                        item.CreatedDate = DateTime.Now;
                        item.CreatedBy = GetLoginEmployeeId();
                        item.ComponentStatusId = (int)ComponentTrackingStatus.Assign;
                        _componentAssetMappingService.CreateComponentAssetMapping(item);
                        ComponentTrackerModel componentTrackerModel = new ComponentTrackerModel
                        {
                            AssetID = createdAsset.ID,
                            ComponentID = item.ComponentID,
                            ComponentStatusID = (int)ComponentTrackingStatus.Assign,
                            CreatedBy = GetLoginEmployeeId(),
                            CreatedDate = DateTime.Now
                        };
                        _componentTrackerService.CreateComponentTracker(componentTrackerModel);
                    }
                }
            }
            return softwareAssetModel;
        }

        public HardwareAssetModel EditHardwareAsset(int assetID)
        {
            HardwareAssetModel hardwareAssetModel = new HardwareAssetModel();
            var asset = _assetRepository.GetAssetByID(assetID);
            var hardwareAsset = _hardwareAssetService.GetHardwareAssetByAssetID(assetID);
            if (asset != null)
            {
                hardwareAssetModel = new HardwareAssetModel
                {
                    AssetID = asset.ID,
                    AssetName = asset.AssetName,
                    SerialNumber = asset.SerialNumber,
                    AssetTypeID = asset.AssetTypeID,
                    AssetStatusID = asset.AssetStatusID,
                    AssetCategoryId = asset.AssetTypes.AssetCategoryID,
                    CreatedDate = asset.CreatedDate,
                    CreatedBy = asset.CreatedBy,
                };
            }
            if(hardwareAsset != null)
            {
                hardwareAssetModel.Model = hardwareAsset.Model;
                hardwareAssetModel.ServiceTag = hardwareAsset.ServiceTag;
                hardwareAssetModel.Manufacturer = hardwareAsset.Manufacturer;
                hardwareAssetModel.WarrantyStartDate = hardwareAsset.WarrantyStartDate;
                hardwareAssetModel.WarrantyEndDate = hardwareAsset.WarrantyEndDate;
                hardwareAssetModel.Comment = hardwareAsset.Comment;
            }
            var componentAssetMapping = _componentAssetMappingService.GetComponentAssetMappingsByAssetID(assetID);
            if(componentAssetMapping != null && componentAssetMapping.Count > 0)
            {
                hardwareAssetModel.ComponentAssetMapping = componentAssetMapping.ToList();
            }
            return hardwareAssetModel;
        }

        public SoftwareAssetModel EditSoftwareAsset(int assetID)
        {
            SoftwareAssetModel softwareAssetModel = new SoftwareAssetModel();
            var asset = _assetRepository.GetAssetByID(assetID);
            var softwareAsset = _softwareAssetService.GetSoftwareAssetByAssetID(assetID);
            if (asset != null)
            {
                softwareAssetModel = new SoftwareAssetModel
                {
                    AssetID = asset.ID,
                    AssetName = asset.AssetName,
                    SerialNumber = asset.SerialNumber,
                    AssetTypeID = asset.AssetTypeID,
                    AssetStatusID = asset.AssetStatusID,
                    AssetCategoryId = asset.AssetTypes.AssetCategoryID,
                    CreatedDate = asset.CreatedDate,
                    CreatedBy = asset.CreatedBy,                   
                };
            }
            if(softwareAsset != null)
            {
                softwareAssetModel.ProductName = softwareAsset.ProductName;
                softwareAssetModel.LicenceNumber = softwareAsset.LicenceNumber;
                softwareAssetModel.LicencePurchaseDate = softwareAsset.LicencePurchaseDate;
                softwareAssetModel.LicenceExpiryDate = softwareAsset.LicenceExpiryDate;
                softwareAssetModel.Comment = softwareAsset.Comment;
            }
            var componentAssetMapping = _componentAssetMappingService.GetComponentAssetMappingsByAssetID(assetID);
            if (componentAssetMapping != null && componentAssetMapping.Count > 0)
            {
                softwareAssetModel.ComponentAssetMapping = componentAssetMapping.ToList();
            }
            return softwareAssetModel;
        }

        public HardwareAssetModel EditCloneHardwareAsset(int assetID)
        {
            HardwareAssetModel hardwareAssetModel = new HardwareAssetModel();
            var asset = _assetRepository.GetAssetByID(assetID);
            var hardwareAsset = _hardwareAssetService.GetHardwareAssetByAssetID(assetID);
            if (asset != null)
            {
                hardwareAssetModel = new HardwareAssetModel
                {
                    AssetID = asset.ID,
                    AssetName = asset.AssetName,
                    SerialNumber = asset.SerialNumber,
                    AssetTypeID = asset.AssetTypeID,
                    AssetStatusID = asset.AssetStatusID,
                    AssetCategoryId = asset.AssetTypes.AssetCategoryID,
                    CreatedDate = asset.CreatedDate,
                    CreatedBy = asset.CreatedBy,
                };
            }
            if (hardwareAsset != null)
            {
                hardwareAssetModel.Model = hardwareAsset.Model;
                hardwareAssetModel.ServiceTag = hardwareAsset.ServiceTag;
                hardwareAssetModel.Manufacturer = hardwareAsset.Manufacturer;
                hardwareAssetModel.WarrantyStartDate = hardwareAsset.WarrantyStartDate;
                hardwareAssetModel.WarrantyEndDate = hardwareAsset.WarrantyEndDate;
                hardwareAssetModel.Comment = hardwareAsset.Comment;
            }
            var componentAssetMapping = _componentAssetMappingService.GetComponentAssetMappingsByAssetID(assetID);
            if (componentAssetMapping != null && componentAssetMapping.Count > 0)
            {
                hardwareAssetModel.ComponentAssetMapping = componentAssetMapping.ToList();
            }
            return hardwareAssetModel;
        }
           public List<ComponentAssetMappingModel> GetComponentAssetMappings(int assetID)
        {
            var componentAssetMapping = _componentAssetMappingService.GetComponentAssetMappingsByAssetID(assetID);
            return componentAssetMapping;
        }

        public SoftwareAssetModel EditCloneSoftwareAsset(int assetID)
        {
            SoftwareAssetModel softwareAssetModel = new SoftwareAssetModel();
            var asset = _assetRepository.GetAssetByID(assetID);
            var softwareAsset = _softwareAssetService.GetSoftwareAssetByAssetID(assetID);
            if (asset != null)
            {
                softwareAssetModel = new SoftwareAssetModel
                {
                    AssetID = asset.ID,
                    AssetName = asset.AssetName,
                    SerialNumber = asset.SerialNumber,
                    AssetTypeID = asset.AssetTypeID,
                    AssetStatusID = asset.AssetStatusID,
                    AssetCategoryId = asset.AssetTypes.AssetCategoryID,
                    CreatedDate = asset.CreatedDate,
                    CreatedBy = asset.CreatedBy,
                };
            }
            if (softwareAsset != null)
            {
                softwareAssetModel.ProductName = softwareAsset.ProductName;
                softwareAssetModel.LicenceNumber = softwareAsset.LicenceNumber;
                softwareAssetModel.LicencePurchaseDate = softwareAsset.LicencePurchaseDate;
                softwareAssetModel.LicenceExpiryDate = softwareAsset.LicenceExpiryDate;
                softwareAssetModel.Comment = softwareAsset.Comment;
            }
            var componentAssetMapping = _componentAssetMappingService.GetComponentAssetMappingsByAssetID(assetID);
            if (componentAssetMapping != null && componentAssetMapping.Count > 0)
            {
                softwareAssetModel.ComponentAssetMapping = componentAssetMapping.ToList();
            }
            return softwareAssetModel;
        }
        public int GetLoginEmployeeId()
        {
            return _employeeService.GetEmployeeId();
        }
        public HardwareAssetModel UpdateHardwareAsset(HardwareAssetModel hardwareAssetModel)
        {
            Assets selectedAsset = _assetRepository.GetAssetByID(hardwareAssetModel.AssetID);
            if (selectedAsset != null)
            {
                selectedAsset.AssetName = hardwareAssetModel.AssetName;
                selectedAsset.SerialNumber = hardwareAssetModel.SerialNumber;
                selectedAsset.AssetTypeID = hardwareAssetModel.AssetTypeID;
                selectedAsset.AssetStatusID = (int)AssetTrackingStatus.New;
            }
            _assetRepository.UpdateAsset(selectedAsset);

            _hardwareAssetService.UpdateHardwareAsset(hardwareAssetModel);

            if (hardwareAssetModel.ComponentAssetMapping != null)
            {
                if (hardwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory == true|| fet.ComponentID != 0).ToList().Count > 0)
                {
                    foreach (var item in hardwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory == true|| fet.ComponentID != 0).ToList())
                    {
                        item.AssignedAssetID = selectedAsset.ID;
                        item.ActualAssetID = selectedAsset.ID;
                        item.AssignedDate = DateTime.Now;
                        item.AssignedBy = GetLoginEmployeeId();
                        item.ComponentStatusId = (int)ComponentTrackingStatus.Assign;
                        _componentAssetMappingService.UpdateComponentAssetMapping(item);
                        ComponentTrackerModel componentTrackerModel = new ComponentTrackerModel
                        {
                            AssetID = selectedAsset.ID,
                            ComponentID = item.ComponentID,
                            ComponentStatusID = (int)ComponentTrackingStatus.Assign,
                            CreatedBy = GetLoginEmployeeId(),
                            CreatedDate = DateTime.Now
                        };
                        _componentTrackerService.CreateComponentTracker(componentTrackerModel);
                    }
                }
            }

            return hardwareAssetModel;
        }
        public SoftwareAssetModel UpdateSoftwareAsset(SoftwareAssetModel softwareAssetModel)
        {
            Assets selectedAsset = _assetRepository.GetAssetByID(softwareAssetModel.AssetID);
            if (selectedAsset != null)
            {
                selectedAsset.AssetName = softwareAssetModel.AssetName;
                selectedAsset.SerialNumber = softwareAssetModel.SerialNumber;
                selectedAsset.AssetTypeID = softwareAssetModel.AssetTypeID;
                selectedAsset.AssetStatusID = (int)AssetTrackingStatus.New;
            }
            _assetRepository.UpdateAsset(selectedAsset);

            _softwareAssetService.UpdateSoftwareAsset(softwareAssetModel);

            if (softwareAssetModel.ComponentAssetMapping != null)
            {
                if (softwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory ==true || fet.ComponentID != 0).ToList().Count > 0)
                {
                    foreach (var item in softwareAssetModel.ComponentAssetMapping.Where(fet => fet.Mandatory == true || fet.ComponentID != 0).ToList())
                    {
                        item.AssignedAssetID = selectedAsset.ID;
                        item.ActualAssetID = selectedAsset.ID;
                        item.AssignedDate = DateTime.Now;
                        item.AssignedBy = GetLoginEmployeeId();
                        item.ComponentStatusId = (int)ComponentTrackingStatus.Assign;
                        _componentAssetMappingService.UpdateComponentAssetMapping(item);
                        ComponentTrackerModel componentTrackerModel = new ComponentTrackerModel
                        {
                            AssetID = selectedAsset.ID,
                            ComponentID = item.ComponentID,
                            ComponentStatusID = (int)ComponentTrackingStatus.Assign,
                            CreatedBy = GetLoginEmployeeId(),
                            CreatedDate = DateTime.Now
                        };
                        _componentTrackerService.CreateComponentTracker(componentTrackerModel);
                    }
                }
            }
            return softwareAssetModel;
        }
        public List<ComponentTypeModel> GetComponentTypes()
        {
            var componentTypes = _componentTypeService.GetActiveComponentTypes();
            return componentTypes;
        }
        public List<ComponentsModel> GetComponents()
        {
            var components = _componentsService.GetActiveComponents();
            return components;
        }
        public int CreateComponent(ComponentsModel component)
        {
            return _componentsService.createComponents(component);
        }
        public List<AssetModel> GetAssets()
        {
            List<AssetModel> assetModels = new List<AssetModel>();
            var assets = _assetRepository.GetAssets();
            if (assets != null && assets.Count > 0)
            {
                var ddlEmployees = _employeeService.GetDropdownEmployees();
                return assets.Select(asset => GetAssetModel(asset, ddlEmployees)).ToList();
            }
            else
            {
                return new List<AssetModel> { };
            }
        }
        public AssetModel GetAssetByID(int Id)
        {
            var asset = _assetRepository.GetAssetByID(Id);
            if (asset != null)
            {
                var ddlEmployees = _employeeService.GetDropdownEmployees();
                return GetAssetModel(asset, ddlEmployees);
            }
            else
            {
                return new AssetModel { };
            }
        }

        public int AssignAsset(AssetModel assetModel)
        {

            EmployeeAssetMappingModel employeeAssetMappingModel = new EmployeeAssetMappingModel
            {
                EmployeeID = assetModel.EmployeeID,
                AssetID = assetModel.ID,
                CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID
            };

            var employeeAssetMapping = _employeeAssetMappingRepository.CreateEmployeeAssetMapping(new EmployeeAssetMapping
            {
                AssetID = assetModel.ID,
                EmployeeID = assetModel.EmployeeID,
                CreatedDate = assetModel.AssignDate,
                CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,

            });

            if (employeeAssetMapping != null && employeeAssetMapping.ID != 0)
            {
                int id = _assetTrackerService.CreateAssetTracker(new AssetTrackerModel
                {
                    AssetID = assetModel.ID,
                    EmpID = assetModel.EmployeeID,
                    AssetStatusID = (int)AssetTrackingStatus.Assign,
                    CreatedDate = DateTime.Now,
                    CreatedBy = employeeAssetMappingModel.CreatedBy,
                    Remarks = assetModel.Remarks
                });
                if (id != 0)
                {
                    assetModel.AssetStatusID = (int)AssetTrackingStatus.Assign;
                    id = UpdateAsset(assetModel);
                }
            }


            return assetModel.ID;
        }

        public void UnassignAsset(AssetModel assetModel)
        {

            if (assetModel.ID != 0 && assetModel.EmployeeID != 0)
            {
                var employeeAssetMapping = _employeeAssetMappingRepository.GetEmployeeAssetMappings().Where(m => m.AssetID == assetModel.ID && m.EmployeeID == assetModel.EmployeeID).First();

                if (employeeAssetMapping != null)
                {
                    _employeeAssetMappingRepository.DeleteEmployeeAssetMappingByID(employeeAssetMapping.ID);
                }
            }

            int id = _assetTrackerService.CreateAssetTracker(new AssetTrackerModel
            {
                AssetID = assetModel.ID,
                EmpID = assetModel.EmployeeID,
                AssetStatusID = (int)AssetTrackingStatus.Unassign,
                CreatedDate = DateTime.Now,
                CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID,
                Remarks = assetModel.Remarks
            });

            if (id != 0)
            {
                assetModel.AssetStatusID = (int)AssetTrackingStatus.Unassign;
                id = UpdateAsset(assetModel);
            }
        }

        public int UpdateAsset(AssetModel assetModel)
        {
            Assets asset = _assetRepository.GetAssetByID(assetModel.ID);
            if (asset != null)
            {
                asset.AssetName = assetModel.AssetName;
                asset.AssetTypeID = assetModel.AssetTypeID;
                asset.SerialNumber = assetModel.SerialNumber;
                asset.AssetStatusID = assetModel.AssetStatusID;
                asset.CreatedDate = assetModel.CreatedDate;
                asset.CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID;
            }

            _assetRepository.UpdateAsset(asset);

            return asset.ID;
        }

        private AssetModel GetAssetModel(Assets asset, SelectList ddlEmployees)
        {
            AssetModel assetModel = new AssetModel
            {
                ID = asset.ID,
                AssetName = asset.AssetName,
                AssetTypeID = asset.AssetTypeID,
                AssetType = asset.AssetTypes.Description,
                SerialNumber = asset.SerialNumber,
                AssetStatusID = asset.AssetStatusID,
                AssetStatus = asset.AssetStatus.Description,
                CreatedDate = asset.CreatedDate,
                CreatedBy = asset.CreatedBy,
                CategoryID = asset.AssetTypes.AssetCategoryID,
                GetEmployees = ddlEmployees
            };

            var employeeAssetMapping = asset.EmployeeAssetMapping.Where(eam => eam.AssetID == asset.ID).FirstOrDefault();

            if (employeeAssetMapping != null)
            {
                assetModel.EmployeeID = employeeAssetMapping.EmployeeID;
                assetModel.EmployeeName = employeeAssetMapping.Employee.EmployeeName;
            }

            return assetModel;
        }

        public List<HardwareAssetModel> AutoCompleteForModel(string prefix)
        {
            var Model = _hardwareAssetService.GetAssetCategories().Where(ha => ha.Model.ToLower().StartsWith(prefix.ToLower()));

            return Model.Select(ha => new HardwareAssetModel
            {
                Model = ha.Model
            }).ToList();
        }

        public List<HardwareAssetModel> AutoCompleteForManufacturer(string prefix)
        {
            var Manufacturer = _hardwareAssetService.GetAssetCategories().Where(ha => ha.Manufacturer.ToLower().StartsWith(prefix.ToLower()));
            Manufacturer = Manufacturer.Distinct().ToList();

            return Manufacturer.Select(ha => new HardwareAssetModel
            {
                Manufacturer = ha.Manufacturer
            }).ToList();
        }
    }
}
