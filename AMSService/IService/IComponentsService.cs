using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AMSRepository.Models;
using AMSUtilities.Models;

namespace AMSService.Service
{
   public interface IComponentsService
    {
        List<ComponentsModel> GetActiveComponents();
        int createComponents(ComponentsModel componentsModel);
        string UpdateComponents(ComponentsModel componentsModel);
        List<ComponentsModel> AllActiveComponents();
        List<ComponentsModel> GetAllComponents();
        ComponentsModel GetComponentsById(int id);
        ComponentsModel GetComponents(Components componentsModel, SelectList ddltypes);
    }
}
