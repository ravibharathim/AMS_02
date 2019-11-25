using AMSService.Service;
using AMSUtilities.Enums;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace NLTDAMS.Controllers
{
    public class AssetCategoryController : Controller
    {
        private readonly IAssetCategoryService _assetCategoryService;
        private readonly ILog _logger;
        public AssetCategoryController(IAssetCategoryService assetCategoryService, ILog logger)
        {
            _assetCategoryService = assetCategoryService;
            _logger = logger;
        }
        // GET: AssetCategory
        public ActionResult List()
        {
            return View(_assetCategoryService.GetAssetCategories());
        }      

        // GET: AssetCategory/Create
        public ActionResult Create()
        {
            return View(_assetCategoryService.GetCategoryeModel(null));
        }

        // POST: AssetCategory/Create
        [HttpPost]
        public ActionResult Create(AssetCategoryModel assetCategoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _assetCategoryService.CreateAssetCategory(assetCategoryModel);

                    TempData["Message"] = "Asset Category created successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("List");
                }
                else
                {
                    return View(assetCategoryModel);
                }
            }
            catch(Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Asset Category not created. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(assetCategoryModel);
            }
        }

        // GET: AssetCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_assetCategoryService.GetCategoryeModel(id));
        }

        // POST: AssetCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AssetCategoryModel assetCategoryModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _assetCategoryService.UpdateAssetCategory(assetCategoryModel);
                    TempData["Message"] = "Asset Category updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("List");
                }
                else
                {
                    return View(assetCategoryModel);
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Asset Category not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(assetCategoryModel);
            }
        }

        // GET: AssetCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetCategory/Delete/5
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
