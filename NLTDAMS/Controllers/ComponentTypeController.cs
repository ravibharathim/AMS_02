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
    public class ComponentTypeController : Controller
    {
        private readonly IComponentTypeService _ComponentTypeService;
        private readonly ILog _logger;
        private readonly IAssetTypeService _assetTypeService;
        public ComponentTypeController(IComponentTypeService ComponentTypeService, ILog logger, IAssetTypeService assetTypeService)
        {
            _ComponentTypeService = ComponentTypeService;
            _logger = logger;
            _assetTypeService = assetTypeService;
        }
        // GET: ComponentType
        public ActionResult List()
        {
            return View(_ComponentTypeService.GetComponentTypes());
        }        

        // GET: ComponentType/Create
        public ActionResult Create()
        {
            var componentTypeModel= _ComponentTypeService.GetComponentTypeModel(null, assetCategoryId: (int)AssetCategories.Hardware);
            componentTypeModel.AssetCategoryId = (int)AssetCategories.Hardware;
            return View(componentTypeModel);
        }

        // POST: ComponentType/Create
        [HttpPost]
        public ActionResult Create(ComponentTypeModel componentTypeModel, int? assetCategoryId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ComponentTypeService.CreateComponentType(componentTypeModel);

                    TempData["Message"] = "Component type created successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("List");
                }
                else
                {
                    if (assetCategoryId != 0)
                    {
                        var componentType = _ComponentTypeService.GetComponentTypeModel(null, assetCategoryId: assetCategoryId);
                        componentType.AssetCategoryId = assetCategoryId.Value;
                        return View(componentType);
                        
                    }
                    else
                    {
                        var componentType = _ComponentTypeService.GetComponentTypeModel(null, assetCategoryId: (int)AssetCategories.Hardware);
                        componentType.AssetCategoryId = (int)AssetCategories.Hardware;
                        return View(componentType);
                    }
                    
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Component type not created. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(componentTypeModel);
            }
        }
        public JsonResult SetAssetTypes(int? assetCategoryId)
        {

            try
            {
                var assetTypes = _assetTypeService.GetDropdownAssetTypes(assetCategoryId);
                if (assetTypes != null)
                {
                    return Json(assetTypes, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // GET: ComponentType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_ComponentTypeService.GetComponentTypeModel(id));
        }

        // POST: ComponentType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ComponentTypeModel componentTypeModel, int? assetCategoryId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ComponentTypeService.UpdateComponentType(componentTypeModel);
                    TempData["Message"] = "Component Type updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("List");
                }
                else
                {
                    return View(componentTypeModel);
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Component Type not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(componentTypeModel);
            }
        }

        public ActionResult ComponentTypeStatus(int id, bool status)
        {
            try
            {
                if (_ComponentTypeService.ComponentTypeStatus(id, status))
                {
                    TempData["Message"] = "Component Type status updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                }
                else
                {
                    TempData["Message"] = "Component Type not available.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Warning;
                }
            }
            catch (Exception e)
            {

                _logger.Error(e);
                TempData["Message"] = "Internal server error. Component Type not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
            }
            return RedirectToAction("List");
        }        

        // GET: ComponentType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComponentType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComponentType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
