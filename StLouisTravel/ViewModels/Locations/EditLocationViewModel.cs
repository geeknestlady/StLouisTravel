using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.ViewModels.Locations
{
    public class EditLocationViewModel
    {
        private readonly RepositoryFactory repositoryFactory;

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required(ErrorMessage = "Region is required")]
        public string Region { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "Must be between 2 and 200 characters")]
        public string Description { get; set; }

        public EditLocationViewModel() { }

       

        public EditLocationViewModel(int id)
        {
            Location location = repositoryFactory.GetLocationRepository().GetById(id);
            this.Name = location.Name;
            this.Address = location.Address;
            this.Region = location.Region;
            this.Description = location.Description;
        }

        public void Update(int id, RepositoryFactory repositoryFactory)
        {
            Models.Location location = new Models.Location
            {
                Id = id,
                Name = this.Name,
                Address = this.Address,
                Region = this.Region,
                Description = this.Description
            };
            repositoryFactory.GetLocationRepository().Update(location);
        }
    }
}
