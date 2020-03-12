using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class ResultController : Controller
    {

        IList<ResultModel> results;

        public ResultController()
        {
            results = new List<ResultModel>{
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 } ,
                        new ResultModel() { InputString = "", ResponseString = "John", ResultId = 18 }
                    };
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(results);
        }

        public ActionResult ResultList()
        {
            return PartialView(results);
        }
    }
}