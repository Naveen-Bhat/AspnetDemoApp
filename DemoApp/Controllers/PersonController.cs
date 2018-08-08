using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class PersonController : Controller
    {
        private static List<PersonViewModel> people = new List<PersonViewModel>();

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(PersonViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return View("Success");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        //public IActionResult Success()
        //{
        //    return View();
        //}

        [HttpPost]
        public JsonResult SavePerson(PersonViewModel viewModel)
        {
            people.Add(viewModel);
            return Json(new { data = "Saved successfully!" });
        }

        [HttpGet]
        public JsonResult GetPeople()
        {
            return Json(people);
        }

        public JsonResult Search(string pattern)
        {
            var result = people.Where(x => x.Name.Contains(pattern));

            return Json(result);
        }
    }
}