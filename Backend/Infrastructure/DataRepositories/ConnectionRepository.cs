using Domain.Common;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class ConnectionRepository(DomainDBContext context) : IConnectionRepository
    {
        private readonly DomainDBContext _context = context;

        public bool Add(Connection connection) 
        {
            _context.Connection.Add(connection);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Connection connection) 
        {
            _context.Connection.Remove(connection);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Connection> GetAll()
        {
            return [.. _context.Connection];
        }

        public Connection? GetByID(int id)
        {
            return _context.Connection.FirstOrDefault(a => a.ID == id);
        }

        public bool Update(Connection connection) 
        {
            _context.Connection.Update(connection);
            return _context.SaveChanges() == 1;
        }
    }
}
