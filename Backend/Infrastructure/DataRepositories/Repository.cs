using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DomainDBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DomainDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            if (_context.SaveChanges() != 1) return -1;

            var propertyInfo = entity.GetType().GetProperty("ID");
            object? value;
            if (propertyInfo != null && (value = propertyInfo.GetValue(entity)) != null)
            {
                return (int)value;
            }
            throw new InvalidOperationException("The entity does not have an ID property.");
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<T> GetAll()
        {
            return [.. _dbSet];
        }

        public T? GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public bool Update(T entity)
        {
            _dbSet.Update(entity);
            return _context.SaveChanges() == 1;
        }
    }
}
