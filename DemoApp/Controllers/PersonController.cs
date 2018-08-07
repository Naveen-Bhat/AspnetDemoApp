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
            return Json(new { data = "Saved successfully!" });
        }
    }
}