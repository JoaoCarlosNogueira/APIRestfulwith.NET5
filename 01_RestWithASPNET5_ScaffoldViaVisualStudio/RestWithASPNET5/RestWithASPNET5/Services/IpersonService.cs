using RestWithASPNET5.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNET5.Services
{
    public interface IpersonService{
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
    }
}
