using AMSRepository.Repository;
using AMSRepository.Models;
using AMSUtilities.Common;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IEmployeeService _employeeService;
        public VendorService(IVendorRepository vendorRepository, 
            IEmployeeService employeeService)
        {
            _vendorRepository = vendorRepository;
            _employeeService = employeeService;
        }

        public VendorModel GetVendorModel(int? Id = null)
        {
            if (Id.HasValue)
            {
                Vendor vendor = _vendorRepository.GetVendorByID(Id.Value);
                if (vendor != null)
                {
                    return new VendorModel
                    {
                        ID = vendor.ID,
                        Name = vendor.Name,
                        Address = vendor.Address,
                        Email = vendor.Email,
                        ContactNumber = vendor.ContactNumber,
                        ContactPerson = vendor.ContactPerson
                    };
                }
                else
                {
                    throw new EntryPointNotFoundException();
                }
            }
            else
            {
                return new VendorModel { };
            }
        }

        public int CreateVendor(VendorModel vendorModel)
        {
            try
            {
                Vendor vendor = null;
                vendor = _vendorRepository.CreateVendor(new Vendor()
                {
                    Name = vendorModel.Name,
                    Address = vendorModel.Address,
                    Email = vendorModel.Email,
                    ContactNumber = vendorModel.ContactNumber,
                    ContactPerson = vendorModel.ContactPerson,
                    CreatedBy = _employeeService.GetEmployeeByCorpId(HttpContext.Current.User.Identity.Name).ID

                });
                return vendor.ID;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateVendor(VendorModel vendorModel)
        {
            Vendor vendor = _vendorRepository.GetVendorByID(vendorModel.ID);
            if (vendor != null)
            {
                vendor.Name = vendorModel.Name;
                vendor.Address = vendorModel.Address;
                vendor.Email = vendorModel.Email;
                vendor.ContactNumber = vendorModel.ContactNumber;
                vendor.ContactPerson = vendorModel.ContactPerson;
            }
            _vendorRepository.UpdateVendor(vendor);
            return vendor.ID;
        }

        public List<VendorModel> GetVendors()
        {
            var vendors = _vendorRepository.GetVendors();

            if (vendors != null)
            {
                return vendors.Select(v => new VendorModel
                {
                    ID = v.ID,
                    Name = v.Name,
                    Address = v.Address,
                    Email = v.Email,
                    ContactNumber = v.ContactNumber,
                    ContactPerson = v.ContactPerson,
                    CreatedDate = v.CreatedDate,
                    CreatedBy = v.CreatedBy
                }).ToList();
            }
            else
            {
                return new List<VendorModel> { };
            }
        }

        public SelectList GetDropdownVendors(int selectedId = -1)
        {
            List<SelectListItem> VerdorsItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Vendor", Value = "" } };
            var Verdors = _vendorRepository.GetVendors();
            if (Verdors != null && Verdors.Count > 0)
            {
                Verdors.ForEach(at =>
                {
                    VerdorsItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = at.Name, Value = at.ID.ToString() });
                });
            }

            return new SelectList(VerdorsItems, "Value", "Text");
        }
    }
}
