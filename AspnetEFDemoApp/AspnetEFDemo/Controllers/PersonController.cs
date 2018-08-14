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
        // GET: Person
        public ActionResult Index()
        {
            List<Person> people = new List<Person>();

            var p = people.Where(x => 1==1).Take(10);


            using (var context = new InternshipDbEntities())
            {
                people = context.People.ToList();
            }

            return View(people);
        }

        public ActionResult Create(PersonModel person)
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
        public ActionResult SavePerson(PersonModel personModel)
        {
            if (ModelState.IsValid)
            {
                using (var context = new InternshipDbEntities())
                {
                    var person = new Person
                    {
                        Name = personModel.Name,
                        Address = new Address()
                        {
                            Address1 = personModel.Adddress
                        }
                    };

                    context.People.Add(person);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            return View("Create", personModel);
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