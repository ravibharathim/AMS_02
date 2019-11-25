using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AMSService.Service;
using AMSUtilities.Models;
using Unity;
using log4net;
using AMSUtilities.Enums;

namespace NLTDAMS.Controllers
{
    public class ComponentsController : Controller
    {
        IComponentsService _componentsService;
        IComponentTypeService _componentTypeService;
        IComponentAssetMappingService _componentAssetMappingService;
        private readonly ILog _logger;
        public ComponentsController(IComponentsService componentsService, IComponentTypeService componentTypeService, IComponentAssetMappingService componentAssetMappingService, ILog logger)
        {
            _componentsService = componentsService;
            _componentTypeService = componentTypeService;
            _componentAssetMappingService = componentAssetMappingService;
            _logger = logger;
        }
            

        // GET: Components
        public ActionResult Index()
        {
            var Components = _componentsService.GetAllComponents();
            return View(Components);
          
        }
        public ActionResult NewComponents()
        {
            ComponentsModel components = new ComponentsModel
            {
                ComponentType = _componentTypeService.GetDropdownComponentTypes()
            };           
            return View(components);
        }
        [HttpPost]
        public ActionResult NewComponents(ComponentsModel components)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _componentsService.createComponents(components);
                    TempData["Message"] = "Component type created successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("NewComponents");
            
                    
                }
               
            
            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Component type not created. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View("Index");
            }
           
        }

        public ActionResult UpdateComponents(int id)
        {
            return View(_componentsService.GetComponentsById(id));


        }

        [HttpPost]
        public ActionResult UpdateComponents(int id,ComponentsModel componentModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _componentsService.UpdateComponents(componentModel);
                    TempData["Message"] = "Component updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("Index");
                }
                else
                {

                    return View(componentModel);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Component not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(componentModel);
            }

        }       

    }
}