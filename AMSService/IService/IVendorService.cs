using System.Collections.Generic;
using AMSUtilities.Models;

namespace AMSService.Service
{
    public interface IVendorService
    {
        int CreateVendor(VendorModel vendorModel);
        System.Web.Mvc.SelectList GetDropdownVendors(int selectedId = -1);
        VendorModel GetVendorModel(int? Id = null);
        List<VendorModel> GetVendors();
        int UpdateVendor(VendorModel vendorModel);
    }
}