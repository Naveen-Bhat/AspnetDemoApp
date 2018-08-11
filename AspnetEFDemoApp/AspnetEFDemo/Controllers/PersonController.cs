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
            List<Person> people = null;

            using (var context = new InternshipDbEntities())
            {
                people = context.People.ToList();
            }

            return View(people);
        }

        public ActionResult Create(Person person)
        {
            return View(person);
        }

        public ActionResult Update(int personId)
        {
            Person person = null;

            using (var context = new InternshipDbEntities())
            {
                person = context.People.Where(x => x.Id == personId).SingleOrDefault();
            }

            return View(person);
        }

        [HttpPost]
        public ActionResult SavePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                using (var context = new InternshipDbEntities())
                {
                    context.People.Add(person);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View("CreateOrUpdate", person);
        }

        [HttpPost]
        public ActionResult UpdatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                using (var context = new InternshipDbEntities())
                {
                    var personObj = context.People.Where(x => x.Id == person.Id).SingleOrDefault();

                    if (personObj != null)
                    {
                        personObj.Name = person.Name;
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }

            return View("CreateOrUpdate", person);
        }

        public JsonResult Delete(int personId)
        {
            using (var context = new InternshipDbEntities())
            {
                var person = context.People.Where(x => x.Id == personId).SingleOrDefault();
                if (person != null)
                {
                    context.People.Remove(person);
                    context.SaveChanges();
                }
            }

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
    }
}