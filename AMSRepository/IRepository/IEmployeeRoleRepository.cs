using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IEmployeeRoleRepository
    {
        EmployeeRole CreateEmployeeRole(EmployeeRole employeeRole);
        EmployeeRole GetEmployeeRoleByID(int employeeRoleID);
        List<EmployeeRole> GetEmployeeRoles();
        EmployeeRole UpdateEmployeeRole(EmployeeRole employeeRole);
    }
}