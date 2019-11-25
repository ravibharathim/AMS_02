using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class ComponentsRepository : BaseRepository<Components>, IComponentsRepository
    {
        public Components CreateComponent(Components component)
        {
            return Insert(component);
        }

        public Components UpdateComponent(Components component)
        {
            return Update(component);
        }

        public List<Components> GetComponents()
        {
            return GetAll();
        }
        public Components GetComponentsByID(int componentID)
        {
            return GetByID(componentID);
        }

        public List<Components> AllActiveComponents()
        {

            var list = (from ct in context.ComponentType.Where(fet => fet.IsActive == true) join c in context.Components on ct.ID equals c.ComponentTypeID select c).ToList();
            return list;
        }
    }
}
