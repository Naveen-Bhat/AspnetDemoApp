using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers
{
    public class FooController : Controller
    {
        public IActionResult Bar()
        {
            return View();
        }
    }
}