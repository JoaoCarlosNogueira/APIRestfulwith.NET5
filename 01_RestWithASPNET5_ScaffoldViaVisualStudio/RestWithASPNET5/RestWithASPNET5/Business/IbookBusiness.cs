using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public interface IbookBusiness
    {
        BookVO Create(BookVO bookVO);
        BookVO Update(BookVO bookVo);
        void Delete(long id);
        BookVO FindById(long id);
        List<BookVO> FindAll();
    }
}
