using AspnetEFDemo.Business;
using AspnetEFDemo.Models;
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
        private readonly PersonBusiness personBusiness = new PersonBusiness();

        // GET: Person
        public ActionResult Index()
        {
            var people = personBusiness.GetPeople();
            return View(people);
        }

        public ActionResult Create(PersonModel person)
        {
            return View(person);
        }

        public ActionResult Update(int personId)
        {
            Person person = this.personBusiness.GetPersonById(personId);
            return View(person);
        }

        [HttpPost]
        public ActionResult SavePerson(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                this.personBusiness.AddPerson(personModel);
                return RedirectToAction("Index");
            }

            return View("Create", personModel);
        }

        [HttpPost]
        public ActionResult UpdatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                this.personBusiness.UpdatePerson(person);
                return RedirectToAction("Index");
            }

            return View("CreateOrUpdate", person);
        }

        public JsonResult Delete(int personId)
        {
            this.personBusiness.DeletePerson(personId);
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}