using AMSService.Service;
using AMSUtilities.Enums;
using AMSUtilities.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLTDAMS.Controllers
{
    public class QuotationController : Controller
    {
        private readonly IQuotationService _quotationService;
        private readonly ILog _logger;
        private readonly IVendorService _vendorService;
        public QuotationController(IQuotationService quotationService, ILog logger, IVendorService vendorService)
        {
            _quotationService = quotationService;
            _logger = logger;
            _vendorService = vendorService;
        }
        // GET: Quotation
        public ActionResult ManageQuotation()        
        {
            var quotations = _quotationService.GetQuotations();
            return View(quotations);
        }

        // GET: Quotation/Create
        public ActionResult Create()
        {
            return View(_quotationService.GetQuotationModel(null));
        }

        // POST: Quotation/Create
        [HttpPost]
        public ActionResult Create(QuotationModel quotationModel, HttpPostedFileBase QuotationFile)
        {
            try
            {
                quotationModel.Vendorddl = _vendorService.GetDropdownVendors();
                if (ModelState.IsValid)
                {
                    string path = Server.MapPath("~/Content/Quotation/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (QuotationFile != null)
                    {
                        quotationModel.QuotationFilePath = string.Format("{0:yyyy-MM-dd_HH-mm-ss-fff}", quotationModel.QuotationReceivedDate) + ".pdf";
                        string fileName = Path.GetFileName(QuotationFile.FileName);
                        fileName = quotationModel.QuotationFilePath;
                        QuotationFile.SaveAs(path + fileName);
                        
                    }
                    _quotationService.CreateQuotation(quotationModel);

                    TempData["Message"] = "Quotation created successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("ManageQuotation");
                }
                else
                {                  
                    return View(quotationModel);
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Vendor not created. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(quotationModel);
            }
        }

        // GET: Quotation/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quotationService.GetQuotationModel(id));
        }

        // POST: Quotation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, QuotationModel quotationModel, HttpPostedFileBase QuotationFile)
        {
            try
            {
                quotationModel.Vendorddl = _vendorService.GetDropdownVendors();
                if (ModelState.IsValid)
                {
                    string path = Server.MapPath("~/Content/Quotation/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    if (QuotationFile != null)
                    {
                        quotationModel.QuotationFilePath = string.Format("{0:yyyy-MM-dd_HH-mm-ss-fff}", quotationModel.QuotationReceivedDate) + ".pdf";
                        string fileName = Path.GetFileName(QuotationFile.FileName);
                        fileName = quotationModel.QuotationFilePath;
                        QuotationFile.SaveAs(path + fileName);
                    }
                    _quotationService.UpdateQuotation(quotationModel);
                    TempData["Message"] = "Quotation updated successfully.";
                    TempData["MessageType"] = (int)AlertMessageTypes.Success;
                    return RedirectToAction("ManageQuotation");
                }
                else
                {
                    return View(_quotationService);
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                TempData["Message"] = "Internal server error. Vendor not updated. Please contact administrator.";
                TempData["MessageType"] = (int)AlertMessageTypes.Danger;
                return View(_quotationService);
            }
        }
    }
}