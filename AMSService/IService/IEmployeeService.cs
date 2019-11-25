using AMSUtilities.Models;
using System.Web.Mvc;

namespace AMSService.Service
{
    public interface IEmployeeService
    {
        
        EmployeeModel GetEmployeeByCorpId(string corpId);
        SelectList GetDropdownEmployees(int selectedId = -1);
        int GetEmployeeId(string corpId = null);
    }
}