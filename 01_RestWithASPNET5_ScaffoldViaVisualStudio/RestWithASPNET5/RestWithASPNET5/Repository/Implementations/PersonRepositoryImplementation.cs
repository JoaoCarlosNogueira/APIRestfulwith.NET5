using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IpersonRepository
    {
        private MySQLContext context;


        public PersonRepositoryImplementation(MySQLContext _context)
        {
            context = _context;
        }

        public List<Person> FindAll()
        {
            return context.People.ToList();
        }

        public Person FindById(long id)
        {
            return context.People.SingleOrDefault(p => p.Id.Equals(id));
        }
        public Person Create(Person person)
        {
            try
            {
                context.Add(person);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;
            var result = context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    context.Entry(result).CurrentValues.SetValues(person);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }

            }
            return person;
        }
        public void Delete(long id)
        {
            var result = context.People.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    context.People.Remove(result);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        } 

        public bool Exists(long id)
        {

            return context.People.Any((p => p.Id.Equals(id)));
        }

      
    }
}
