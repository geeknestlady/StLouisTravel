using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisTravel.ViewModels.Categories;
using StLouisTravel.Data;

namespace StLouisTravel.Controllers
{
    public class CategoryController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public CategoryController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }


        public IActionResult Index()
        {
            List<CategoryListViewModel> categories = CategoryListViewModel.GetCategories(repositoryFactory);
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}