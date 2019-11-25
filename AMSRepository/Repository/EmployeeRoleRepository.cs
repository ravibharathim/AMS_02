using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class EmployeeRoleRepository : BaseRepository<EmployeeRole>, IEmployeeRoleRepository
    {
        public EmployeeRole CreateEmployeeRole(EmployeeRole employeeRole)
        {
            return Insert(employeeRole);
        }

        public EmployeeRole UpdateEmployeeRole(EmployeeRole employeeRole)
        {
            return Update(employeeRole);
        }

        public List<EmployeeRole> GetEmployeeRoles()
        {
            return GetAll();
        }
        public EmployeeRole GetEmployeeRoleByID(int employeeRoleID)
        {
            return GetByID(employeeRoleID);
        }
    }
}
