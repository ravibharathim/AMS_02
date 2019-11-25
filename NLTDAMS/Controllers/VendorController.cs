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
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;
        private readonly ILog _logger;

        public VendorController(IVendorService vendorService, ILog logger)
        {
            _vendorService = vendorService;
            _logger = logger;
        }

        // GET: Vendor
        public ActionResult List()
        {
            return View(_vendorService.GetVendors());
        }      

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View(_vendorService.GetVendorModel(null));
        }

        // POST: Vendor/Create
        [HttpPost]
        public ActionResult Create(VendorModel vendorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _vendorService.CreateVendor(vendorModel);

                    TempData["Message"] = "Vendor created successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("List");
                }
                else
                {
                    return View(vendorModel);
                }
            }
            catch(Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Vendor not created. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(vendorModel);
            }
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_vendorService.GetVendorModel(id));
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, VendorModel vendorModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _vendorService.UpdateVendor(vendorModel);
                    TempData["Message"] = "Vendor updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("List");
                }
                else
                {
                    return View(_vendorService);
                }

            }
            catch(Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Vendor not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(_vendorService);
            }
        }

        // GET: Vendor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vendor/Delete/5
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
