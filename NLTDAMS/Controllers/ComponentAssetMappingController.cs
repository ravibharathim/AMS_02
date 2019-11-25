using AMSService.Service;
using AMSUtilities.Enums;
using AMSUtilities.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLTDAMS.Controllers
{
    public class ComponentAssetMappingController : Controller
    {
        private readonly IComponentAssetMappingService _componentAssetMappingService;
        private readonly ILog _logger;
        public ComponentAssetMappingController(IComponentAssetMappingService componentAssetMappingService, ILog logger)
        {
            _componentAssetMappingService = componentAssetMappingService;
            _logger = logger;
        }
        // GET: ComponentAssetMapping
        public ActionResult List()
        {

            var Components = _componentAssetMappingService.GetComponentAssetMappings();
            return View(Components);
        }

        public ActionResult AssignComponents(int ID)
        {
            var components = _componentAssetMappingService.GetComponentByID(ID);
            return PartialView("../Shared/_AssignComponents", components);

        }

        public ActionResult UnassignComponents(int ID)
        {
            var components = _componentAssetMappingService.GetComponentByID(ID);
            return PartialView("../Shared/_UnAssignComponents", components);
        }

        [HttpPost]
        public ActionResult AssignComponents(ComponentAssetMappingModel componentAssetMappingModel)
        {
            var componentAssetMapping = _componentAssetMappingService.AssignComponents(componentAssetMappingModel);

            if (componentAssetMapping.ID != 0)
            {
                TempData["Message"] = "Asset assigned successfully.";
                TempData["MessageType"] = (int)AlertMessageTypes.Success;
                return RedirectToAction("List");
            }
            else
            {

                TempData["Message"] = "Asset not assigned.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View("List");
            }
        }

        [HttpPost]
        public ActionResult UnassignComponents(ComponentAssetMappingModel componentModel)
        {
            _componentAssetMappingService.UnassignComponents(componentModel);
            TempData["Message"] = "Asset unassigned successfully.";
            TempData["MessageType"] = (int)AlertMessageTypes.Success;
            return RedirectToAction("List");
        }
    }
}