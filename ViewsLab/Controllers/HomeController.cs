using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewsLab.Models;

namespace ViewsLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "I am learning ASP.NET Core MVC";
            return View("SampleView");
        }

        [HttpPost]
        public IActionResult About(Models.Movie movieIncoming)
        {
            // Your logic here

            return View(movieIncoming);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            Movie movie = new Movie
            {
                ID = 1,
                Title = "Follow the Wind",
                ReleaseDate = new DateTime(2017, 01, 21)
            };
            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
