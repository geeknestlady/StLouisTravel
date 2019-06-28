using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisTravel.Data;
using StLouisTravel.Models;
using StLouisTravel.ViewModels.Feedbacks;

namespace StLouisTravel.Controllers
{
    public class FeedbackController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public FeedbackController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int locationId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int locationId, FeedbackCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction(controllerName: nameof(Location), actionName: nameof(Index));
        }

    
    }
}