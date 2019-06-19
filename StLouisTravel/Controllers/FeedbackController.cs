using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return View();
        }

    
    }
}