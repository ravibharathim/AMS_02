using AMSRepository.Models;
using AMSRepository.Repository;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public int CreateEmployee(EmployeeModel employeeModel)
        {
            Employee employee = null;
            employee = this._employeeRepository.CreateEmployee(new Employee()
            {
                EmployeeID = employeeModel.EmployeeID,
                EmployeeRoleID = employeeModel.EmployeeRoleID,
                EmployeeName = employeeModel.EmployeeName,
                SeatID = employeeModel.SeatID,
                MailID = employeeModel.MailID,
                CreatedDate = employeeModel.CreatedDate,
                CreatedBy = employeeModel.EmployeeID,
                ISActive = employeeModel.ISActive,
                ManagerID = employeeModel.ManagerID,
                CorpId = employeeModel.CorpId,
            });

            return employee.ID;
        }
        public int UpdateEmployee(EmployeeModel employeeModel)
        {
            Employee employee = _employeeRepository.GetEmployeeByID(employeeModel.ID);
            if (employee != null)
            {
                employee.EmployeeID = employeeModel.EmployeeID;
                employee.EmployeeRoleID = employeeModel.EmployeeRoleID;
                employee.EmployeeName = employeeModel.EmployeeName;
                employee.SeatID = employeeModel.SeatID;
                employee.MailID = employeeModel.MailID;
                employee.CreatedDate = employeeModel.CreatedDate;
                employee.CreatedBy = employeeModel.EmployeeID;
                employee.ISActive = employeeModel.ISActive;
                employee.ManagerID = employeeModel.ManagerID;
                employee.CorpId = employeeModel.CorpId;
            }
            _employeeRepository.UpdateEmployee(employee);

            return employee.ID;
        }
        public EmployeeModel GetEmployeeByCorpId(string corpId)
        {
            try
            {
                var employee = _employeeRepository.GetEmployees().Where(e => e.CorpId.ToLower() == corpId.ToLower()).FirstOrDefault();
                if (employee != null)
                {
                    return new EmployeeModel
                    {
                        ID = employee.ID,
                        EmployeeName = employee.EmployeeName,
                        EmployeeID = employee.EmployeeID,
                        CorpId = employee.CorpId,
                        EmployeeRoleID = employee.EmployeeRoleID,
                        ISActive = employee.ISActive,
                        MailID = employee.MailID,
                        SeatID = employee.SeatID
                    };
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<EmployeeModel> GetAssetCategories()
        {
            var employees = _employeeRepository.GetEmployees();
            if (employees != null && employees.Count > 0)
            {
                return employees.Select(ac => new EmployeeModel
                {
                    ID = ac.ID,
                    EmployeeID = ac.EmployeeID,
                    EmployeeRoleID = ac.EmployeeRoleID,
                    EmployeeName = ac.EmployeeName,
                    SeatID = ac.SeatID,
                    MailID = ac.MailID,
                    CreatedDate = ac.CreatedDate,
                    CreatedBy = ac.EmployeeID,
                    ISActive = ac.ISActive,
                    ManagerID = ac.ManagerID,
                    CorpId = ac.CorpId,
                }).ToList();
            }
            else
            {
                return new List<EmployeeModel> { };
            }
        }
        public SelectList GetDropdownEmployees(int selectedId = -1)
        {
            List<SelectListItem> EmployeesItems = new List<SelectListItem> { new SelectListItem { Selected = selectedId == -1 ? true : false, Text = "Select Employee", Value = "" } };
            var Employees = _employeeRepository.GetEmployees();
            if (Employees != null && Employees.Count > 0)
            {
                Employees.ForEach(at =>
                {
                    EmployeesItems.Add(new SelectListItem { Selected = selectedId == at.ID ? true : false, Text = at.EmployeeName, Value = at.ID.ToString() });
                });
            }

            return new SelectList(EmployeesItems, "Value", "Text");
        }
        public int GetEmployeeId(string corpId = null)
        {
            if (corpId == null)
            {
                corpId = HttpContext.Current.User.Identity.Name;
            }
            var employee = _employeeRepository.GetEmployeeByCorpID(corpId);
            return employee.ID;
        }
    }
}
