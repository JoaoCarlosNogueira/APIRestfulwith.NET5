using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Model.Base;
using RestWithASPNET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext _context)
        {
            dataset= _context.Set<T>();
            context = _context;
        }

        public List<T> FindAll()
        {
           return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public T Update(T item)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(item));
            if (result != null)
                try
            {

                 context.Entry(result).CurrentValues.SetValues(item);
                 context.SaveChanges();
                    return item;
            }
            catch (Exception)
            {
                throw;
                }
            else
            {
                return null;
            }

        }
        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
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
            return dataset.Any(p => p.Id.Equals(id));
        }

    }
}
