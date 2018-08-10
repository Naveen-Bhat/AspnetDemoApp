using AspnetEFDemo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetEFDemo.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            var entitis = new InternshipDbEntities();
            var people = entitis.People.ToList();

            return View(people);
        }
    }
}