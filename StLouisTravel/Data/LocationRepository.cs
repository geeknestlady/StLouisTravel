﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StLouisTravel.Models;

namespace StLouisTravel.Data
{
    public class LocationRepository : ILocationRepository
    {
        private List<Location> locations = new List<Location>();
        private static int nextId = 1;

        public void Delete(int id)
        {
            locations.RemoveAll(d => d.Id == id);
        }

        public Location GetById(int id)
        {
            return locations.SingleOrDefault(d => d.Id == id);
        }

        public List<Location> GetLocations()
        {
            return locations;
        }

        public int Save(Location location)
        {
            location.Id = nextId++;
            locations.Add(location);
            return location.Id;
        }

        public void Update(Location location)
        {
            this.Delete(location.Id);
            locations.Add(location);
        }
    }
}
