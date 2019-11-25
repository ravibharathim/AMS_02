using System.Collections.Generic;
using AMSRepository.Models;

namespace AMSRepository.Repository
{
    public interface ILocationRepository
    {
        Location CreateLocation(Location location);
        Location GetLocationByID(int locationID);
        List<Location> GetLocations();
        Location UpdateLocation(Location location);
    }
}