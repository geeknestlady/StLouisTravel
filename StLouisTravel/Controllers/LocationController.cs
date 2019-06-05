using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisTravel.Models;
using StLouisTravel.Data;

namespace StLouisTravel.Controllers
{
    public class LocationController : Controller
    {

        private ILocationRepository locationRepository = RepositoryFactory.GetLocationRepository();

        public IActionResult Index()
        {
            List<Location> locations = locationRepository.GetLocations().ToList();
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            locationRepository.Save(location);
            return RedirectToAction(actionName: nameof(Index));
        }

    }
}