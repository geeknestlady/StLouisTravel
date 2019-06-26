using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StLouisTravel.ViewModels.Feedbacks;

namespace StLouisTravel.Controllers
{
    public class FeedbackController : Controller
    {
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
            return View();
        }

    
    }
}