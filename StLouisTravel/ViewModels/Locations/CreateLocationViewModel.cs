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

        [Display(Name = "Select one or more categories")]
        public List<int> CategoryIds { get; set; }
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "Must be between 2 and 200 characters" )]
        public string Description { get; set; }
            
                     

        public CreateLocationViewModel() { }

        public CreateLocationViewModel(RepositoryFactory factory)
        {
            this.Categories = factory.GetCategoryRepository()
                .GetModels()               
                .ToList();
        }


        public void Persist(RepositoryFactory repositoryFactory)
        {
            Models.Location location = new Models.Location
            {
                Name = this.Name,
                Address = this.Address,
                Region = this.Region,
                Description = this.Description
            };
            
            List<CategoryLocation> locationCategories = CreateManyToManyRelationships(location.Id);
            location.CategoryLocations = locationCategories;
            repositoryFactory.GetLocationRepository().Save(location);
        }

        private List<CategoryLocation> CreateManyToManyRelationships(int locationId)
        {
            return CategoryIds.Select(catId => new CategoryLocation { LocationId = locationId, CategoryId = catId }).ToList();
        }

        internal void ResetCategoryList(RepositoryFactory factory)
        {
            this.Categories = factory.GetCategoryRepository()
               .GetModels()
               .ToList();
        }
    }
    }
