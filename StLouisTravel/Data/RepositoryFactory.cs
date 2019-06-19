using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisTravel.Models;

namespace StLouisTravel.Data
{
    public static class RepositoryFactory
    {
        private static IRepository locationRepository;

        public static IRepository GetLocationRepository()
        {
            if (locationRepository == null)
                locationRepository = new LocationRepository();
            return locationRepository;
        }

    }

}
