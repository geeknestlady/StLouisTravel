using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.ViewModels.Locations
{
    public class CreateLocationViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Region { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
       

        public CreateLocationViewModel() { }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Address = this.Address,
                Region = this.Region,
                Description = this.Description
            };
            repositoryFactory.GetLocationRepository().Save(location);
        }

    }
    }
