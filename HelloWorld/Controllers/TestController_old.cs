using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorld.Controllers
{
    public class TestController_old : Controller
    {

        private readonly ILogger<TestController_old> _logger;

        public TestController_old(ILogger<TestController_old> logger)
        {
            _logger = logger;
        }

        // GET: /<controller>/
        public IActionResult Test()
        {
            var resultsList = new List<ResultModel>{
                            new ResultModel() { InputString = "xxxxxxxxxxxxxxx", ResponseString = "John", ResultId = 12 } ,
                            new ResultModel() { InputString = "xxxxxxxxxxxxxxx", ResponseString = "John", ResultId = 13 } ,
                            new ResultModel() { InputString = "xxxxxxxxxxxxxxx", ResponseString = "John", ResultId = 14 } ,
                            new ResultModel() { InputString = "xxxxxxxxxxxxxxx", ResponseString = "John", ResultId = 15 } ,
                            new ResultModel() { InputString = "xxxxxxxxxxxxxxx", ResponseString = "John", ResultId = 16 } ,
                            new ResultModel() { InputString = "xxxxxxxxxxxxxxx", ResponseString = "John", ResultId = 17 } ,
                            new ResultModel() { InputString = "xxxxxxxxxxxxxxx", ResponseString = "John", ResultId = 18 }
                        };
            //TestModel test = new TestModel(resultsList);
            return View();
        }
    }
}
