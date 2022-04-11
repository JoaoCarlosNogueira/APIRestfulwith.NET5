using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;
using System.Collections.Generic;

namespace RestWithASPNET5.Business.Implementations
{
    public class BookBusinessImplementation : IbookBusiness
    
    {
        public IbookRepository _ibookRepository;

        public BookBusinessImplementation(IbookRepository ibookRepository)
        {
            _ibookRepository = ibookRepository;
        }

        public Book Create(Book book)
        {
           return _ibookRepository.Create(book);
        }

        public void Delete(long id)
        {
             _ibookRepository.Delete(id);
        }

        public List<Book> FindAll()
        {
             return _ibookRepository.FindAll();
        }

        public Book FindById(long id)
        {
            return _ibookRepository.FindById(id);
        }

        public Book Update(Book book)
        {
           return _ibookRepository.Update(book);
        }
    }
}
