using AMSService.Service;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using AMSUtilities.Models;
using AMSUtilities.Enums;

namespace NLTDAMS.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService;
        ILog _logger;
        public AssetController(IAssetService assetService, ILog logger)
        {
            _logger = logger;
            _assetService = assetService;
        }
        ResourceManager rm = new ResourceManager("NLTDAMS.Properties.Resources", Assembly.GetExecutingAssembly());
        // GET: Asset
        public ActionResult CreateAsset()
        {
            AssetModel assetModel = new AssetModel();
            try
            {
                var assetCategories = _assetService.GetAssetCategories();
                assetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description");
                return View(assetModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return View(assetModel);
            }
        }
        public ActionResult HardwareAsset()
        {

            HardwareAssetModel hardwareAssetModel = new HardwareAssetModel();
            try
            {
                var assetCategories = _assetService.GetAssetCategories();
                hardwareAssetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description", (int)AssetCategories.Hardware);

                var assetTypes = _assetService.GetAssetTypes((int)AssetCategories.Hardware);
                hardwareAssetModel.AssetTypes = assetTypes;
                hardwareAssetModel.ComponentTypeModels = _assetService.GetComponentTypes();
                hardwareAssetModel.ComponentsModels = _assetService.GetComponents();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(hardwareAssetModel);
        }
        public ActionResult CloneHardwareAsset(int assetId)
        {
            try
            {
                HardwareAssetModel hardwareAssetModel = _assetService.EditCloneHardwareAsset(assetId);
                var assetCategories = _assetService.GetAssetCategories();
                hardwareAssetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description", (int)AssetCategories.Hardware);

                var assetTypes = _assetService.GetAssetTypes((int)AssetCategories.Hardware);
                hardwareAssetModel.AssetTypes = assetTypes;
                hardwareAssetModel.ComponentTypeModels = _assetService.GetComponentTypes();
                hardwareAssetModel.ComponentsModels = _assetService.GetComponents();
                return View("CloneHardwareAsset", hardwareAssetModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return RedirectToAction("ManageAssets");
            }

        }
        [HttpPost]
        public ActionResult CreateHardwareAsset(HardwareAssetModel hardwareAssetModel, bool isClone)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if ((hardwareAssetModel.AssetTypeID == (int)AssetTypes.CPU && hardwareAssetModel.AssetName == null) || (hardwareAssetModel.AssetTypeID == (int)AssetTypes.Laptop && hardwareAssetModel.AssetName == null))
                    {
                        ModelState.AddModelError("AssetName", "Please enter Asset Name");
                        var assetCategories = _assetService.GetAssetCategories();
                        hardwareAssetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description", (int)AssetCategories.Hardware);
                        var assetTypes = _assetService.GetAssetTypes((int)AssetCategories.Hardware);
                        hardwareAssetModel.AssetTypes = assetTypes;
                        hardwareAssetModel.ComponentTypeModels = _assetService.GetComponentTypes();
                        hardwareAssetModel.ComponentsModels = _assetService.GetComponents();
                        return View("HardwareAsset", hardwareAssetModel);
                    }
                    _assetService.CreateHardwareAsset(hardwareAssetModel);
                    TempData["Message"] = "Hardware Asset Created Successfully";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    if (isClone)
                    {
                        TempData["hardwareAssetModel"] = hardwareAssetModel;
                        return RedirectToAction("CloneHardwareAsset", new { assetId = hardwareAssetModel.AssetID });
                    }
                    else
                    {
                        return RedirectToAction("ManageAssets");
                    }
                }
                else
                {
                    return RedirectToAction("HardwareAsset");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error in Creating a hardware asset";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                _logger.Error(ex);
                return RedirectToAction("HardwareAsset");
            }
        }
        public ActionResult SoftwareAsset()
        {
            SoftwareAssetModel softwareAssetModel = new SoftwareAssetModel();
            try
            {
                var assetCategories = _assetService.GetAssetCategories();
                softwareAssetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description", (int)AssetCategories.Software);
                softwareAssetModel.AssetCategoryId = (int)AssetCategories.Software;
                var assetTypes = _assetService.GetAssetTypes((int)AssetCategories.Software);
                softwareAssetModel.AssetTypes = assetTypes;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(softwareAssetModel);
        }
        public ActionResult CloneSoftwareAsset(int assetId)
        {
            try
            {
                SoftwareAssetModel softwareAssetModel = _assetService.EditCloneSoftwareAsset(assetId);
                var assetCategories = _assetService.GetAssetCategories();
                softwareAssetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description", (int)AssetCategories.Software);
                softwareAssetModel.AssetCategoryId = (int)AssetCategories.Software;
                var assetTypes = _assetService.GetAssetTypes((int)AssetCategories.Software, softwareAssetModel.AssetTypeID);
                softwareAssetModel.AssetTypes = assetTypes;
                return View("CloneSoftwareAsset", softwareAssetModel);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return RedirectToAction("ManageAssets");
            }
        }
        [HttpPost]
        public ActionResult CreateSoftwareAsset(SoftwareAssetModel softwareAssetModel, bool isClone)
        {
            try
            {
                _assetService.CreateSoftwareAsset(softwareAssetModel);
                TempData["Message"] = "Software Asset Created Successfully";
                TempData["MessageType"] = (int)AlertMessageTypes.Success;
                if (isClone)
                {
                    //return View("CloneSoftwareAsset", softwareAssetModel);
                    TempData["softwareAssetModel"] = softwareAssetModel;
                    return RedirectToAction("CloneSoftwareAsset",new { assetId=softwareAssetModel.AssetID });
                }
                else
                {
                    return RedirectToAction("ManageAssets");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error in Creating a software asset";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                _logger.Error(ex);
                return RedirectToAction("SoftwareAsset");
            }
        }

        public ActionResult EditHardwareAsset(int Id)
        {
            HardwareAssetModel hardwareAssetModel = _assetService.EditHardwareAsset(Id);
            try
            {
                var assetCategories = _assetService.GetAssetCategories();
                hardwareAssetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description", (int)AssetCategories.Hardware);

                var assetTypes = _assetService.GetAssetTypes((int)AssetCategories.Hardware);
                hardwareAssetModel.AssetTypes = assetTypes;
                hardwareAssetModel.ComponentTypeModels = _assetService.GetComponentTypes();
                hardwareAssetModel.ComponentsModels = _assetService.GetComponents();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(hardwareAssetModel);
        }
        [HttpPost]
        public ActionResult UpdateHardwareAsset(HardwareAssetModel hardwareAssetModel)
        {
            try
            {
                _assetService.UpdateHardwareAsset(hardwareAssetModel);
                TempData["Message"] = "Hardware Asset updated successfully";
                TempData["MessageType"] = (int)AlertMessageTypes.Success;
                return RedirectToAction("ManageAssets");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error in updating a asset";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                _logger.Error(ex);
                return RedirectToAction("ManageAssets");
            }
        }
        public ActionResult EditSoftwareAsset(int Id)
        {
            SoftwareAssetModel softwareAssetModel = _assetService.EditSoftwareAsset(Id);
            try
            {
                var assetCategories = _assetService.GetAssetCategories();
                softwareAssetModel.AssetCategories = new SelectList(assetCategories, "ID", "Description", (int)AssetCategories.Software);
                softwareAssetModel.AssetCategoryId = (int)AssetCategories.Software;
                var assetTypes = _assetService.GetAssetTypes((int)AssetCategories.Software, softwareAssetModel.AssetTypeID);
                softwareAssetModel.AssetTypes = assetTypes;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
            return View(softwareAssetModel);
        }
        [HttpPost]
        public ActionResult UpdateSoftwareAsset(SoftwareAssetModel softwareAssetModel)
        {
            try
            {
                _assetService.UpdateSoftwareAsset(softwareAssetModel);
                TempData["Message"] = "Software Asset updated Successfully";
                TempData["MessageType"] = (int)AlertMessageTypes.Success;
                return RedirectToAction("ManageAssets");
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error in updating a asset";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                _logger.Error(ex);
                return RedirectToAction("ManageAssets");
            }
        }
        public JsonResult CreateComponent(ComponentsModel component)
        {

            try
            {
                var createdComponent = _assetService.CreateComponent(component);
                if (createdComponent != 0)
                {
                    return Json(createdComponent, JsonRequestBehavior.AllowGet);
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
        public ActionResult ManageComponents(int assetType, int? assetId)
        {
            HardwareAssetModel hardwareAssetModel = new HardwareAssetModel();
            if(assetId != 0 && assetId != null)
            {
                hardwareAssetModel.ComponentAssetMapping = _assetService.GetComponentAssetMappings(assetId.Value);
            }
            hardwareAssetModel.ComponentTypeModels = _assetService.GetComponentTypes().Where(fet => fet.AssetTypeID == assetType).ToList();
            if (hardwareAssetModel.ComponentTypeModels.Count > 0)
            {
                hardwareAssetModel.componentStyle = "display:block";
            }
            else
            {
                hardwareAssetModel.componentStyle = "display:none";
            }
            hardwareAssetModel.ComponentsModels = _assetService.GetComponents();
            return PartialView(hardwareAssetModel);
        }
        public ActionResult ManageSoftwareComponents(int assetType, int? assetId)
        {
            SoftwareAssetModel softwareAssetModel = new SoftwareAssetModel();
            if (assetId != 0 && assetId != null)
            {
                softwareAssetModel.ComponentAssetMapping = _assetService.GetComponentAssetMappings(assetId.Value);
            }
            softwareAssetModel.ComponentTypeModels = _assetService.GetComponentTypes().Where(fet => fet.AssetTypeID == assetType).ToList();
            if (softwareAssetModel.ComponentTypeModels.Count > 0)
            {
                softwareAssetModel.componentStyle = "display:block";
            }
            else
            {
                softwareAssetModel.componentStyle = "display:none";
            }
            softwareAssetModel.ComponentsModels = _assetService.GetComponents();
            return PartialView(softwareAssetModel);
        }
        public ActionResult ManageAssets()
        {
            var Assets = _assetService.GetAssets();
            return View(Assets);
        }

        [HttpPost]
        public ActionResult AssignAsset(AssetModel assetModel)
        {
            int Id = _assetService.AssignAsset(assetModel);

            if (Id != 0)
            {
                TempData["Message"] = "Asset assigned successfully.";
                TempData["MessageType"] = (int)AlertMessageTypes.Success;
                return RedirectToAction("ManageAssets");
            }
            else
            {
                var Assets = _assetService.GetAssets();
                TempData["Message"] = "Asset not assigned.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View("ManageAssets", Assets);
            }
        }

        [HttpPost]
        public ActionResult UnassignAsset(AssetModel assetModel)
        {
            _assetService.UnassignAsset(assetModel);
            TempData["Message"] = "Asset unassigned successfully.";
            TempData["MessageType"] = (int)AlertMessageTypes.Success;
            return RedirectToAction("ManageAssets");
        }

        public ActionResult AssignAsset(int Id)
        {
            var Assets = _assetService.GetAssetByID(Id);
            return PartialView("../Shared/_AssignAsset", Assets);
        }

        public ActionResult UnassignAsset(int Id)
        {
            var Assets = _assetService.GetAssetByID(Id);
            return PartialView("../Shared/_UnassignAsset", Assets);
        }
        public JsonResult IsAssetNameExist(string AssetName, int? AssetID)
        {
            var validateName = _assetService.GetAssets().Where(fet=>fet.AssetName.ToLower() == AssetName.ToLower() && fet.ID!= AssetID).ToList();
            if (validateName.Count()>0)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GetManufacturer(string manufacturer)
        {
            var listOfObjects = _assetService.GetAssets();
            //Searching records from list using LINQ query  
            var manufacturerList = listOfObjects.Where(fet => fet.AssetName.Contains(manufacturer)).ToList();
            return Json(manufacturerList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AutoCompleteForModel(string prefix)
        {
              var Model = _assetService.AutoCompleteForModel(prefix);
              var ModelAuto = (from M in Model                              
                             select new
                             {
                                 label = M.Model,
                                 val = M.Model
                             }).ToList();
            return Json(ModelAuto);
        }

        [HttpPost]
        public ActionResult AutoCompleteForManufacturer(string prefix)
        {
            var Manufacturer = _assetService.AutoCompleteForManufacturer(prefix);
            var ManufacturerAuto = (from M in Manufacturer
                                    select new
                             {
                                 label = M.Manufacturer,
                                 val = M.Manufacturer
                                    }).Distinct().ToList();
            return Json(ManufacturerAuto);
        }
    }
}