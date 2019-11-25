using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMSUtilities.Models;
using AMSRepository.Models;
using AMSRepository.Repository;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class ComponentsService : IComponentsService
    {
        IComponentsRepository _componentRepository;
        IEmployeeService _employeeService;
        IComponentTypeService _componentTypeService;
       public ComponentsService(IComponentsRepository componentsRepository, IEmployeeService employeeService, IComponentTypeService componentTypeService)
        {
            _componentRepository = componentsRepository;
            _employeeService = employeeService;
            _componentTypeService = componentTypeService;
        }
        public List<ComponentsModel> GetActiveComponents()
        {
            var components = _componentRepository.GetComponents().Where(fet=>fet.ComponentType.IsActive==true).ToList();
            ComponentsModel componentsModel = new ComponentsModel();
            if (components != null && components.Count > 0)
            {
                return components.Select(ac => new ComponentsModel
                {
                    ID=ac.ID,
                    ComponentName = ac.ComponentName,
                    Description = ac.Description,
                    ComponentTypeID=ac.ComponentTypeID
                }).ToList();
            }
            else
            {
                return new List<ComponentsModel> { };
            }
        }
        public int createComponents(ComponentsModel componentsModel)
        {
            Components _component = new Components
            {
                ComponentName = componentsModel.ComponentName,
                ComponentTypeID = componentsModel.ComponentTypeID,
                Description = componentsModel.Description,
                CreatedDate=DateTime.Now,
                CreatedBy = GetLoginEmployeeId()
            };
            var objcomponentName = this._componentRepository.CreateComponent(_component);

            return _component.ID;
        }
        public string UpdateComponents(ComponentsModel componentsModel)
        {

            Components UpdateComponents = _componentRepository.GetComponentsByID(componentsModel.ID);

            if (UpdateComponents != null)
            {
                UpdateComponents.ID = componentsModel.ID;
                UpdateComponents.ComponentName = componentsModel.ComponentName;
                UpdateComponents.ComponentTypeID = componentsModel.ComponentTypeID;
                UpdateComponents.Description = componentsModel.Description;
            }
            _componentRepository.UpdateComponent(UpdateComponents);
            return componentsModel.ToString();
        }
        public int GetLoginEmployeeId()
        {
            return _employeeService.GetEmployeeId();
        }
        public List<ComponentsModel> AllActiveComponents()
        {
            var components = _componentRepository.AllActiveComponents();

            if (components != null && components.Count > 0)
            {
                return components.Select(ac => new ComponentsModel
                {
                    ComponentName = ac.ComponentName

                }).ToList();
            }
            else
            {
                return new List<ComponentsModel> { };
            }
        }

        public List<ComponentsModel> GetAllComponents()
        {
            var getComponents = this._componentRepository.GetComponents();
            List<ComponentsModel> getAllComponents = new List<ComponentsModel>();
            getComponents.ForEach(components =>
            {
                ComponentsModel componentsViewModel = new ComponentsModel();
                componentsViewModel.ID = components.ID;
                componentsViewModel.ComponentName = components.ComponentName;
                componentsViewModel.ComponentTypeID = components.ComponentTypeID;
                componentsViewModel.ComponentTypeName = components.ComponentType.Name;
                componentsViewModel.Description = components.Description;

                //componentsViewModel.IsActive = components.ComponentType.IsActive;
                //componentsViewModel.AssetID = components.ComponentAssetMapping.Where(cam => cam.ComponentID == components.ID).Select(cam=> cam.AssignedAssetID).FirstOrDefault(); 
                //componentsViewModel.AssetName = (from s in components.ComponentAssetMapping where s.ComponentID.Equals(components.ID) select s.Assets.AssetName).SingleOrDefault();
                //componentsViewModel.ComponentStatusID = (from s in components.ComponentAssetMapping where s.ComponentID.Equals(components.ID) select s.ComponentStatusId).SingleOrDefault();
                //componentsViewModel.ComponentStatus = (from s in components.ComponentAssetMapping where s.ComponentID.Equals(components.ID) select s.ComponentStatus.Description).SingleOrDefault();


                getAllComponents.Add(componentsViewModel);
            });

            return getAllComponents;

        }

        public ComponentsModel GetComponentsById(int id)
        {
            var getComponentsbyID = _componentRepository.GetComponentsByID(id);
            if (getComponentsbyID != null)
            {
                var ddltypes = _componentTypeService.GetDropdownComponentTypes();
                return GetComponents(getComponentsbyID, ddltypes);
            }
            else
            {
                _componentTypeService.GetDropdownComponentTypes();
                return new ComponentsModel { };
            }
        }

        public ComponentsModel GetComponents(Components componentsModel, SelectList ddltypes)
        {
            ComponentsModel componetModel = new ComponentsModel
            {
                ID = componentsModel.ID,
                ComponentName = componentsModel.ComponentName,
                ComponentTypeID = componentsModel.ComponentTypeID,
                ComponentTypeName = componentsModel.ComponentType.Name,
                Description = componentsModel.Description,
                ComponentType = ddltypes
            };

            return componetModel;
        }
    }
}
