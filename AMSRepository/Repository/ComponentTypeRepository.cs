using AMSRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSRepository.Repository
{
    public class ComponentTypeRepository : BaseRepository<ComponentType>, IComponentTypeRepository
    {
        public ComponentType CreateComponentType(ComponentType componentType)
        {
            return Insert(componentType);
        }

        public ComponentType UpdateComponentType(ComponentType componentType)
        {
            return Update(componentType);
        }

        public List<ComponentType> GetComponentTypes()
        {
            return GetAll();
        }
        public ComponentType GetComponentTypeByID(int componentTypeID)
        {
            return GetByID(componentTypeID);
        }
    }
}
