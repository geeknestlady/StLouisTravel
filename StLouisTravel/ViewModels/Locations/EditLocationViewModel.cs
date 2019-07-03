using StLouisTravel.Data;
using StLouisTravel.Models;
using StLouisTravel.ViewModels.Categories;
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
        [Display(Name = "Select one or more categories")]
        public List<int> CategoryIds { get; set; }
        public List<Category> Categories { get; set; }
        public List<CategoryListViewModel> Selected { get; set; }
        public List<CategoryListViewModel> Unselected { get; set; }

        public EditLocationViewModel() { }

       

        public EditLocationViewModel(int id, RepositoryFactory repositoryFactory)
        {
            Location location = repositoryFactory.GetLocationRepository().GetById(id);
            List<CategoryLocation> categoriesLocators = repositoryFactory.GetCategoryLocationRepository()
                .GetModels()
                .Where(c => c.LocationId == id)
                .ToList();
             Name = location.Name;
             Address = location.Address;
             Region = location.Region;
             Description = location.Description;
             CategoryIds = categoriesLocators.Select(cat => cat.CategoryId).ToList();
             Categories = repositoryFactory.GetCategoryRepository()
               .GetModels()
               .ToList();

            //List<CategoryListViewModel> selected = new List<CategoryListViewModel>();
            //List<CategoryListViewModel> unselected = new List<CategoryListViewModel>();

            //foreach(var category in Categories)
            //{
            //    foreach(var categoryId in CategoryIds)
            //    {
            //        CategoryListViewModel cat = new CategoryListViewModel();
            //        if (categoryId == category.Id)
            //        {
            //            cat.Name = category.Name;
            //            cat.Id = category.Id;
            //            selected.Add(cat);
            //        }
                 
            //    }
            //}

            //Selected = selected;
            //Unselected = unselected;
        }

        public void Update(int id, RepositoryFactory repositoryFactory)
        {
            Models.Location location = new Models.Location
            {
                Id = id,
                Name = this.Name,
                Address = this.Address,
                Region = this.Region,
                Description = this.Description,
                
        };
            List<CategoryLocation> locationCategories = CreateManyToManyRelationships(location.Id, repositoryFactory);
            location.CategoryLocations = locationCategories;
            repositoryFactory.GetLocationRepository().Update(location);
        }
        private List<CategoryLocation> CreateManyToManyRelationships(int locationId, RepositoryFactory repositoryFactory)
        {
            List<Models.CategoryLocation> cats =
                repositoryFactory.GetCategoryLocationRepository()
                .GetModels()
                .Where(s => s.LocationId == locationId)
                .ToList();
            foreach (var item in cats)
            {
                repositoryFactory.GetCategoryLocationRepository().DeleteMany(item);
            }

            return CategoryIds
                .Select(catId => new Models.CategoryLocation { LocationId = locationId, CategoryId = catId })
                .ToList();
        }
        internal void ResetCategoryList(RepositoryFactory factory)
        {
            this.Categories = factory.GetCategoryRepository()
               .GetModels()
               .ToList();
        }
    }
}
