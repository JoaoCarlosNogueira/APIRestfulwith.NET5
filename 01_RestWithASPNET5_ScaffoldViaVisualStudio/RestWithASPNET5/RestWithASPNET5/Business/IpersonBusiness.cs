using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNET5.Business
{
    public interface IpersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO Update(PersonVO person);
        void Delete(long id);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
    }
}
