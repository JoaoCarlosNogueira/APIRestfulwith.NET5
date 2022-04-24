using RestWithASPNET5.Data.Converter.Contract;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Data.Converter.Implementations
{
    public class BookConverter : IParser<Book, BookVO>, IParser<BookVO, Book>
    {
        public BookVO Parse(Book origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
                return new BookVO
                {
                    Id = origin.Id,
                    Title = origin.Title,
                    Author = origin.Author,
                    Price = origin.Price,
                    Launch_date = origin.Launch_date,
                };
        }
        public Book Parse(BookVO origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
                return new Book
                {
                    Id = origin.Id,
                    Title = origin.Title,
                    Author = origin.Author,
                    Price = origin.Price,
                    Launch_date = origin.Launch_date,
                };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
        public List<Book> Parse(List<BookVO> origin)
        {
            return origin.Select(item => Parse(item)).ToList();

        }
    }
}
