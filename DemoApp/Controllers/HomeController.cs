using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoApp.Models;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new HowToViewModel();

            var elm1 = new HowToElementViewModel();
            elm1.Link = "https://go.microsoft.com/fwlink/?LinkID=398600";
            elm1.Text = "Add a Controller and View";
            viewModel.HowToElements.Add(elm1);

            viewModel.HowToElements.Add(new HowToElementViewModel()
            {
                Link = "https://go.microsoft.com/fwlink/?LinkID=699315",
                Text = "Manage User Secrets using Secret Manager"
            });

            viewModel.HowToElements.Add(new HowToElementViewModel()
            {
                Link = "https://go.microsoft.com/fwlink/?LinkID=699316",
                Text = "Use logging to log a message"
            });

            return View(viewModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
