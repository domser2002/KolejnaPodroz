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
    public class ProviderRepository(DomainDBContext context) : IProviderRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(Provider Provider)
        {
            _context.Provider.Add(Provider);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Provider Provider)
        {
            _context.Provider.Remove(Provider);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Provider> GetAll()
        {
            return [.. _context.Provider];
        }

        public Provider? GetByID(int id)
        {
            return _context.Provider.FirstOrDefault(a => a.ID == id);
        }

        public bool Update(Provider Provider)
        {
            _context.Provider.Update(Provider);
            return _context.SaveChanges() == 1;
        }
    }
}
