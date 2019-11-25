using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface IEmployeeRepository
    {
        Employee CreateEmployee(Employee employee);
        Employee GetEmployeeByID(int employeeID);
        List<Employee> GetEmployees();
        Employee UpdateEmployee(Employee employee);
        Employee GetEmployeeByCorpID(string cortpId);
    }
}