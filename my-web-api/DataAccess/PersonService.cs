using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ExpenseItApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseItApi.DataAccess
{
    public class PersonService
    {
        private readonly ExpenseItContext _context;
        private readonly IMapper _mapper;

        public PersonService(ExpenseItContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<Person> GetAllPeople() 
        {
            return _context.Person
                                   .AsNoTracking()
                                   .ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Person.FirstOrDefault(t => t.id == id);
        }

        public void CreatePerson(Person person)
        {
            person.id = 0;
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            var personToUpdate = _context.Person
                                          .AsNoTracking()
                                          .FirstOrDefault(t => t.id == person.id);
            if (personToUpdate == null)
            {
                throw new ArgumentNullException();
            }

            _context.Person.Update(person);
            _context.SaveChanges(); 
        }

        public void DeletePerson(int id)
        {
            var person = _context.Person.FirstOrDefault(t => t.id == id);
            if (person == null)
            {
                throw new ArgumentNullException();
            }
            _context.Person.Remove(person);
            _context.SaveChanges();
        }
    }
}
