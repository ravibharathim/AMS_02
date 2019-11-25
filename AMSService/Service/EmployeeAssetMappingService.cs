using AMSRepository.Repository;
using AMSRepository.Models;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSService.Service
{
    public class EmployeeAssetMappingService : IEmployeeAssetMappingService
    {
        private readonly IEmployeeAssetMappingRepository _employeeAssetMappingRepository;
        public EmployeeAssetMappingService(IEmployeeAssetMappingRepository employeeAssetMappingRepository)
        {
            _employeeAssetMappingRepository = employeeAssetMappingRepository;
        }

        public List<EmployeeAssetMappingModel> GetEmployeeAssetMappingsModel()
        {
            var employeeAssetMappings = _employeeAssetMappingRepository.GetEmployeeAssetMappings();
            if (employeeAssetMappings != null && employeeAssetMappings.Count > 0)
            {
                return employeeAssetMappings.Select(eam => new EmployeeAssetMappingModel
                {
                    ID = eam.ID,
                    EmployeeID = eam.EmployeeID,
                    EmployeeName =eam.Employee.EmployeeName,
                    AssetID = eam.AssetID,
                    AssetName = eam.Assets.AssetName,
                    CreatedDate = eam.CreatedDate,
                    CreatedBy = eam.CreatedBy

                }).ToList();
            }
            else
            {
                return new List<EmployeeAssetMappingModel> { };
            }
        }
        //public int CreateEmployeeAssetMapping(EmployeeAssetMappingModel employeeAssetMappingModel)
        //{
        //    EmployeeAssetMapping EmployeeAssetMapping = null;
        //    EmployeeAssetMapping = this._employeeAssetMappingRepository.CreateEmployeeAssetMapping(new EmployeeAssetMapping()
        //    {
        //        EmployeeID = employeeAssetMappingModel.EmployeeID,
        //        AssetID = employeeAssetMappingModel.AssetID,
        //        CreatedDate = DateTime.Now,
        //        CreatedBy = employeeAssetMappingModel.CreatedBy
        //    });
        //    return EmployeeAssetMapping.ID;
        //}

        //public void DeleteEmployeeAssetMapping(int Id)
        //{
        //    this._employeeAssetMappingRepository.DeleteEmployeeAssetMappingByID(Id);
        //}
    }
}
