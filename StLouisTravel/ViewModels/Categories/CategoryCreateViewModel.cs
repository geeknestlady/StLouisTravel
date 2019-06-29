using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.ViewModels.Categories
{
    public class CategoryCreateViewModel
    {
        public int Id { get; set; }
        //public int LocationId { get; set; }
        public string Name { get; set; }

        public CategoryCreateViewModel() { }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Category category = new Category
            {
                Id = this.Id,
                //LocationId = this.LocationId,
                Name = this.Name

            };
            repositoryFactory.GetCategoryRepository().Save(category);
        }
    }
}
