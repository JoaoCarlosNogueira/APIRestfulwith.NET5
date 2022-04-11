using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using RestWithASPNET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Business.Implementations
{
    public class PersonBusinessImplementation : IpersonBusiness
    {
        private IpersonRepository _repository;


        public PersonBusinessImplementation(IpersonRepository _repository)
        {
            this._repository = _repository;
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public Person Update(Person person)
        {
           
            return _repository.Update(person);
        }
        public void Delete(long id)
        {
             _repository.Delete(id);
        } 
    }
}
