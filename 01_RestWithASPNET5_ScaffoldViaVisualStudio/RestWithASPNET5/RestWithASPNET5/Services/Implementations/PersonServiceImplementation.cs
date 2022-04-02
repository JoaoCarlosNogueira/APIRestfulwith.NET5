using RestWithASPNET5.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNET5.Services.Implementations
{
    public class PersonServiceImplementation : IpersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }
        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementandGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Adress = "Uberlandia -Minas Gerais -Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
        List<Person> IpersonService.FindAll()
        {
            List<Person> people = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);

            }
            return people;
        }

        Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementandGet(),
                FirstName = "Persono Name" + i,
                LastName = "Last Name" + i,
                Adress = "Some" + i,
                Gender = "Male"
            };
        }

        private long IncrementandGet()
        {
            return Interlocked.Increment(ref count);
        }

       
    }
}
