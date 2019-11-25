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
    public class AssetTypeController : Controller
    {
        private readonly IAssetTypeService _assetTypeService;
        private readonly ILog _logger;

        public AssetTypeController(IAssetTypeService assetTypeService, ILog logger)
        {
            _assetTypeService = assetTypeService;
            _logger = logger;
        }
        // GET: AssetType
        public ActionResult List()
        {
            return View(_assetTypeService.GetAssetTypes());
        }        

        // GET: AssetType/Create
        public ActionResult Create()
        {
            return View(_assetTypeService.GetAssetTypeModel(null));
        }

        // POST: AssetType/Create
        [HttpPost]
        public ActionResult Create(AssetTypeModel assetTypeModel)
        {
            try
                {
                    if (ModelState.IsValid)
                    {
                        _assetTypeService.CreateAssetType(assetTypeModel);

                        TempData["Message"] = "Asset type created successfully.";
                        TempData["MessageType"] = (int)AlertMessageTypes.Success;
                        return RedirectToAction("List");
                    }
                    else
                    {
                        return View(_assetTypeService.GetAssetTypeModel(assetCategoryID: assetTypeModel.AssetCategoryID));
                    }
                }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Asset Type not created. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(_assetTypeService.GetAssetTypeModel(assetCategoryID: assetTypeModel.AssetCategoryID));
            }
        }

        // GET: AssetType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_assetTypeService.GetAssetTypeModel(id));
        }

        // POST: AssetType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AssetTypeModel assetTypeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _assetTypeService.UpdateAssetType(assetTypeModel);
                    TempData["Message"] = "Asset type updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("List");
                }
                else
                {
                    return View(assetTypeModel);
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Asset Type not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(assetTypeModel);
            }
        }

        // GET: AssetType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetType/Delete/5
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
