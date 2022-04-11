using RestWithASPNET5.Model;
using System.Collections.Generic;

namespace RestWithASPNET5.Repository
{
    public interface IbookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        Book FindById(long id);
        List<Book> FindAll();
        bool Exists(long id);
    }
}
