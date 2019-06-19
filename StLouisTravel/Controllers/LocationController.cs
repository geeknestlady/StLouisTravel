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

        private IRepository locationRepository = RepositoryFactory.GetLocationRepository();

        private ApplicationDbContext context;
        public LocationController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            List<Location> locations = context.Location.ToList();
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

            context.Add(location);
            context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

       
      

    }
}