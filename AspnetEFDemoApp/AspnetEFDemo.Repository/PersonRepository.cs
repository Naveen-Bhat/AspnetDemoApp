using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspnetEFDemo.Repository
{
    public class PersonRepository
    {
        public List<Person> GetPeople()
        {
            List<Person> people = new List<Person>();

            using (var context = new InternshipDbEntities())
            {
                people = context.People.ToList();
            }

            return people;
        }

        public Person GetPersonById(int personId)
        {
            Person person;

            using (var context = new InternshipDbEntities())
            {
                person = context.People.Where(x => x.Id == personId).SingleOrDefault();
            }

            return person;
        }

        public void AddPerson(Person person)
        {
            using (var context = new InternshipDbEntities())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        public void UpdatePerson(Person person)
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
        }

        public void DeletePerson(int personId)
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
        }
    }
}
