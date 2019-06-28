using Microsoft.AspNetCore.Mvc.Rendering;
using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.ViewModels.Locations
{
    public class CreateLocationViewModel
    {
        [Required(ErrorMessage = "Location Name Required")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Region is Required")]
        public string Region { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "Must be between 2 and 200 characters" )]
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
