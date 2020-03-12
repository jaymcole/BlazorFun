using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IList<ResultModel> results;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            results = new List<ResultModel>{
                        new ResultModel() { InputString = "Hello", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "Something", ResponseString = "Bill", ResultId = 18 } ,
                        //new ResultModel() { InputString = "Where", ResponseString = "Tammy", ResultId = 18 } ,
                        //new ResultModel() { InputString = "Is", ResponseString = "Jont", ResultId = 18 } ,
                        //new ResultModel() { InputString = "The", ResponseString = "Frank", ResultId = 18 } ,
                        //new ResultModel() { InputString = "Money", ResponseString = "Pop", ResultId = 18 } ,
                        //new ResultModel() { InputString = "Now", ResponseString = "Tabitha", ResultId = 18 } ,
                        //new ResultModel() { InputString = "Hello", ResponseString = "Wilma", ResultId = 18 } ,
                        //new ResultModel() { InputString = "Again", ResponseString = "Bront", ResultId = 18 }
                    };
            return View(results);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public void Delete(int id)
        {
            for(int i = 0; i < results.Count; i++)
            {
                if (results[i].ResultId == id)
                {
                    results.RemoveAt(i);
                }
            }
        }


        public ActionResult ResultList()
        {
            return PartialView(results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
