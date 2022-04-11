using RestWithASPNET5.Model;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repository.Implementations
{
    public class BookRepositoryImplementation : IbookRepository
    {

        private MySQLContext context;

        public BookRepositoryImplementation(MySQLContext _context)
        {
            this.context = _context;
        }


        public void Delete(long id)
        {
            var result = context.Books.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    context.Books.Remove(result);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

    
        public List<Book> FindAll()
        {
            return context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return context.Books.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                context.Add(book);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        } 
        public Book Update(Book book)
        {
            {
                if (!Exists(book.Id)) return null;
                var result = context.Books.SingleOrDefault(p => p.Id.Equals(book.Id));

                if (result != null)
                {
                    try
                    {
                        context.Entry(result).CurrentValues.SetValues(book);
                        context.SaveChanges();
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                return book;
            }
        }
        public bool Exists(long id)
        {
            return context.Books.Any((p => p.Id.Equals(id)));
        }

    }
}
