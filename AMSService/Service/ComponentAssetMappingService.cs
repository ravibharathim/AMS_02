using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AMSRepository.Models;
using AMSRepository.Repository;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public class ComponentAssetMappingService : IComponentAssetMappingService
    {
        private readonly IComponentAssetMappingRepository _componentAssetMappingRepository;
        private readonly IAssetRepository _assetRepository;
        private readonly IEmployeeService _employeeService;
        public ComponentAssetMappingService(IComponentAssetMappingRepository componentAssetMappingRepository, IAssetRepository assetRepository, IEmployeeService employeeService)
        {
            _componentAssetMappingRepository = componentAssetMappingRepository;
            _assetRepository = assetRepository;
            _employeeService = employeeService;
        }
        public int CreateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping)
        {
            ComponentAssetMapping componentMapping = new ComponentAssetMapping
            {
              ComponentID = componentAssetMapping.ComponentID,
              AssignedAssetID = componentAssetMapping.AssignedAssetID,
              ActualAssetID  = componentAssetMapping.ActualAssetID,
              ComponentStatusId = componentAssetMapping.ComponentStatusId,
              CreatedBy = componentAssetMapping.CreatedBy,
              CreatedDate= componentAssetMapping.CreatedDate,
              AssignedBy= componentAssetMapping.AssignedBy,
              AssignedDate=componentAssetMapping.AssignedDate,
              Mandatory = componentAssetMapping.Mandatory
        };
            var objcomponentMapping = this._componentAssetMappingRepository.CreateComponentAssetMapping(componentMapping);

            return objcomponentMapping.ID;
        }
        public int UpdateComponentAssetMapping(ComponentAssetMappingModel componentAssetMapping)
        {
            ComponentAssetMapping componentAsset = _componentAssetMappingRepository.GetComponentAssetMappingByID(componentAssetMapping.ID);
            if (componentAssetMapping.ID == 0)
            {
                componentAssetMapping.CreatedDate = DateTime.Now;
                componentAssetMapping.CreatedBy = (int)componentAssetMapping.AssignedBy;
                componentAssetMapping.Mandatory = componentAssetMapping.Mandatory;
                componentAssetMapping.ID=CreateComponentAssetMapping(componentAssetMapping);
            }
            else if (componentAsset != null)
            {
                componentAsset.ComponentID = componentAssetMapping.ComponentID;
                componentAsset.AssignedAssetID = componentAssetMapping.AssignedAssetID;
                componentAsset.ActualAssetID = componentAssetMapping.ActualAssetID;
                componentAsset.ComponentStatusId = componentAssetMapping.ComponentStatusId;
                componentAsset.AssignedBy = componentAssetMapping.AssignedBy;
                componentAsset.AssignedDate = componentAssetMapping.AssignedDate;
                componentAsset.Mandatory = componentAssetMapping.Mandatory;
                _componentAssetMappingRepository.UpdateComponentAssetMapping(componentAsset);
            }
            return componentAssetMapping.ID;
        }

        public List<ComponentAssetMappingModel> GetComponentAssetMappingsByAssetID(int assetID)
        {
            var componentAssets = _componentAssetMappingRepository.GetComponentAssetMappingsByAssetID(assetID);
            if (componentAssets != null && componentAssets.Count > 0)
            {
                return componentAssets.Select(cam => new ComponentAssetMappingModel
                {
                   ID=cam.ID,
                   ComponentID = cam.ComponentID,
                   AssignedAssetID = cam.AssignedAssetID,
                   ActualAssetID = cam.ActualAssetID,
                   ComponentStatusId = cam.ComponentStatusId,
                   AssignedBy = cam.AssignedBy,
                   AssignedDate = cam.AssignedDate,
                   ComponentTypeID=cam.Components.ComponentTypeID,
                   AssetCategoryId = cam.Components.ComponentType.AssetCategoryId,
                   Mandatory = cam.Mandatory
                }).ToList();
            }
            else
            {
                return new List<ComponentAssetMappingModel> { };
            }
        }

        public List<ComponentAssetMappingModel> GetComponentAssetMappings()
        {
            var getComponents = this._componentAssetMappingRepository.GetComponentAssetMappings();
            List<ComponentAssetMappingModel> getAllComponents = new List<ComponentAssetMappingModel>();

            getComponents.ForEach(componentmapping =>
            {
                ComponentAssetMappingModel componentsViewModel = new ComponentAssetMappingModel();
                componentsViewModel.ID = componentmapping.ID;
                componentsViewModel.ComponentName = componentmapping.Components.ComponentName;
                componentsViewModel.ComponentID = componentmapping.ComponentID;
                componentsViewModel.ComponentTypeName = componentmapping.Components.ComponentType.Name;
                componentsViewModel.AssignedAssetID = componentmapping.AssignedAssetID;
                componentsViewModel.ComponentStatusId = componentmapping.ComponentStatusId;
               // componentsViewModel.ComponentStatus = componentmapping.ComponentStatus.Description;
                if (componentsViewModel.AssignedAssetID != null && componentsViewModel.ComponentStatusId == 1)
                {
                    componentsViewModel.AssetName = componentmapping.Assets1.AssetName;
                }


                getAllComponents.Add(componentsViewModel);
            });



            return getAllComponents;

        }
        public ComponentAssetMappingModel GetComponentByID(int id)
        {
            var componentmapping = _componentAssetMappingRepository.GetComponentAssetMappingByID(id);
            if (componentmapping != null)
            {

                 var ddlassets = GetDropdownAssets();
                 return GetComponentModel(componentmapping, ddlassets);;
            }
            else
            {
                return new ComponentAssetMappingModel { };
            }
        }
        public ComponentAssetMappingModel AssignComponents(ComponentAssetMappingModel componentAssetMappingModel)
        {
            ComponentAssetMapping assignComponents = _componentAssetMappingRepository.GetComponentAssetMappingByID(componentAssetMappingModel.ID);
            if (assignComponents != null)
            {

                assignComponents.ID = componentAssetMappingModel.ID;
                assignComponents.AssignedAssetID = componentAssetMappingModel.AssignedAssetID;
                assignComponents.AssignedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID;
                assignComponents.AssignedDate = DateTime.Now;
                assignComponents.ComponentStatusId = Convert.ToInt32(AMSUtilities.Enums.ComponentStatus.Assign);


            }
            _componentAssetMappingRepository.UpdateComponentAssetMapping(assignComponents);

            return componentAssetMappingModel;
        }
        public ComponentAssetMappingModel UnassignComponents(ComponentAssetMappingModel componentAssetMappingModel)
        {
            ComponentAssetMapping unassignComponents = _componentAssetMappingRepository.GetComponentAssetMappingByID(componentAssetMappingModel.ID);
            if (unassignComponents != null)
            {


                unassignComponents.ComponentStatusId = Convert.ToInt32(AMSUtilities.Enums.ComponentStatus.Unassign);


            }
            _componentAssetMappingRepository.UpdateComponentAssetMapping(unassignComponents);

            return componentAssetMappingModel;
        }
        public ComponentAssetMappingModel GetComponentModel(ComponentAssetMapping componentmapping, SelectList ddlassets)
        {
            ComponentAssetMappingModel componetModel = new ComponentAssetMappingModel
            {
                ID = componentmapping.ID,
                ComponentName = componentmapping.Components.ComponentName,
                ComponentID = componentmapping.ComponentID,
                ComponentTypeID = componentmapping.Components.ComponentTypeID,
                ComponentTypeName = componentmapping.Components.ComponentType.Name,
                AssignedAssetID = componentmapping.AssignedAssetID,
                AssetName = componentmapping.Assets1.AssetName,
                Assets = ddlassets
            };

            return componetModel;
        }

        public SelectList GetDropdownAssets(int selectedId = -1)
        {
            List<SelectListItem> AssetsItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Asset", Value = "" } };
            var Assets = _assetRepository.GetAssets();
            if (Assets != null && Assets.Count > 0)
            {
                Assets.ForEach(at =>
                {
                    AssetsItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = at.AssetName, Value = at.ID.ToString() });
                });
            }

            return new SelectList(AssetsItems, "Value", "Text");
        }
    }
}
