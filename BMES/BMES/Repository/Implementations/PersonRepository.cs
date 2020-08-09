using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BMES.Models.Shared;
using BMES.Database;

namespace BMES.Repository.Implementations
{
    public class PersonRepository:IPersonRepository
    {
        private BmesDbContext _context;

        public PersonRepository(BmesDbContext context)
        {
            _context = context;
        }

        public Person FindPersonById(long id)
        {
            var person = _context.People.Find(id);
            return person;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            var people = _context.People;
            return people;
        }

        public void SavePerson(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _context.People.Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _context.People.Remove(person);
            _context.SaveChanges();
        }
    }
}
