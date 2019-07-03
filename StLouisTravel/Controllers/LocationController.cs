using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisTravel.Models;
using StLouisTravel.Data;
using StLouisTravel.ViewModels.Locations;

namespace StLouisTravel.Controllers
{
    public class LocationController : Controller
    {

        private RepositoryFactory repositoryFactory;

        public LocationController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            List<ListLocationViewModel> movies = ListLocationViewModel.GetLocations(repositoryFactory);
            return View(movies);
        }

        [HttpGet]
        public IActionResult Create()
        {

            CreateLocationViewModel model = new CreateLocationViewModel(repositoryFactory);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateLocationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ResetCategoryList(repositoryFactory);
                return View(model);
            }

            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            DetailsLocationViewModels detailsViewModel = DetailsLocationViewModels.GetDetails(repositoryFactory, id);
            return View(detailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return View(model: new EditLocationViewModel(id, repositoryFactory));
        }

        [HttpPost]
        public IActionResult Edit(int id, EditLocationViewModel location )
        {
            if (!ModelState.IsValid)
            {
                location.ResetCategoryList(repositoryFactory);
                return View(location);
            }
            location.Update(id, repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }
  


    }
}