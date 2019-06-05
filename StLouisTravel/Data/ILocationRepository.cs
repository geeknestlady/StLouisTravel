using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisTravel.Models;

namespace StLouisTravel.Data
{
    public interface ILocationRepository
    {
        Location GetById(int id);
        List<Location> GetLocations();
        int Save(Location location);
        void Delete(int id);
        void Update(Location location);
    }
}
