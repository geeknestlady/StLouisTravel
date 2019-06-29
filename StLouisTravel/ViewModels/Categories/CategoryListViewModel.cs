using StLouisTravel.Data;
using StLouisTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StLouisTravel.ViewModels.Categories
{
    public class CategoryListViewModel
    {
        internal static List<CategoryListViewModel> GetCategories(RepositoryFactory factory)
        {
            return factory.GetCategoryRepository()
                .GetModels()
                .Select(c => GetListItem(c))
                .ToList();
        }

        private static CategoryListViewModel GetListItem(Category c)
        {
            return new CategoryListViewModel
            {
                Id = c.Id,
                Name = c.Name
            };
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
