using Domain.Admin;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class AdminRepository(DomainDBContext context) : IAdminRepository
    {
        private readonly DomainDBContext _context = context;
        public int Add(Admin Admin)
        {
            int id = !GetAll().Any() ? 1 : GetAll().Max(x => x.ID) + 1;
            Admin.ID = id; // temporary solution
            _context.Admin.Add(Admin);
            return (_context.SaveChanges() == 1) ? id : -1;
        }

        public bool Delete(Admin Admin)
        {
            _context.Admin.Remove(Admin);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Admin> GetAll()
        {
            return [.. _context.Admin];
        }

        public Admin? GetByID(int id)
        {
            return _context.Admin.FirstOrDefault(a => a.ID ==  id);
        }

        public bool Update(Admin Admin)
        {
            _context.Admin.Update(Admin);
            return _context.SaveChanges() == 1;
        }
    }
}
