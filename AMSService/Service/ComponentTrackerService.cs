
using AMSRepository.Models;
using AMSRepository.Repository;
using AMSUtilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AMSService.Service
{
    public class ComponentTrackerService : IComponentTrackerService
    {
        private readonly IComponentTrackerRepository _componentTrackerRepository;
        public ComponentTrackerService(IComponentTrackerRepository componentTrackerRepository)
        {
            _componentTrackerRepository = componentTrackerRepository;
        }
        public int CreateComponentTracker(ComponentTrackerModel componentTrackerModel)
        {
            ComponentTracker componentTracker = _componentTrackerRepository.GetComponentTrackerByID(componentTrackerModel.ID);
            if (componentTracker == null)
            {
                componentTracker = this._componentTrackerRepository.CreateComponentTracker(new ComponentTracker()
                {
                    AssetID = componentTrackerModel.AssetID,
                    ComponentStatusID = componentTrackerModel.ComponentStatusID,
                    ComponentID = componentTrackerModel.ComponentID,
                    CreatedDate = componentTrackerModel.CreatedDate,
                    CreatedBy = componentTrackerModel.CreatedBy,
                    Remarks = componentTrackerModel.Remarks,
                });
            }
            else if (componentTracker.AssetID != componentTrackerModel.AssetID || componentTracker.ComponentID != componentTrackerModel.ComponentID || componentTracker.ComponentStatusID != componentTrackerModel.ComponentStatusID)
            {
                componentTracker = this._componentTrackerRepository.CreateComponentTracker(new ComponentTracker()
                {
                    AssetID = componentTrackerModel.AssetID,
                    ComponentStatusID = componentTrackerModel.ComponentStatusID,
                    ComponentID = componentTrackerModel.ComponentID,
                    CreatedDate = componentTrackerModel.CreatedDate,
                    CreatedBy = componentTrackerModel.CreatedBy,
                    Remarks = componentTrackerModel.Remarks,
                });
            }
           
            return componentTracker.ID;
        }
        public List<ComponentTrackerModel> GetAssetCategories()
        {
            var componentTrackers = _componentTrackerRepository.GetComponentTrackers();
            if (componentTrackers != null && componentTrackers.Count > 0)
            {
                return componentTrackers.Select(ac => new ComponentTrackerModel
                {
                    AssetID = ac.AssetID,
                    ComponentStatusID = ac.ComponentStatusID,
                    ComponentID = ac.ComponentID,
                    CreatedDate = ac.CreatedDate,
                    CreatedBy = ac.CreatedBy,
                    Remarks = ac.Remarks,
                }).ToList();
            }
            else
            {
                return new List<ComponentTrackerModel> { };
            }
        }
    }
}
