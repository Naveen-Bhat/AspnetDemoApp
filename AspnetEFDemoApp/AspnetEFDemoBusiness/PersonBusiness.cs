using AspnetEFDemo.Models;
using AspnetEFDemo.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetEFDemo.Business
{
    public class PersonBusiness
    {
        private readonly PersonRepository personRepository = new PersonRepository();

        public List<Person> GetPeople()
        {
            return this.personRepository.GetPeople();
        }

        public Person GetPersonById(int personId)
        {
            return this.personRepository.GetPersonById(personId);
        }

        public void AddPerson(PersonModel personModel)
        {
            var person = new Person
            {
                Name = personModel.Name,
                Address = new Address()
                {
                    Address1 = personModel.Adddress
                }
            };

            this.personRepository.AddPerson(person);
        }

        public void UpdatePerson(Person person)
        {
            this.personRepository.UpdatePerson(person);
        }

        public void DeletePerson(int personId)
        {
            this.personRepository.DeletePerson(personId);
        }
    }
}
