using Domain.Common;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class UserRepository(DomainDBContext context) : IUserRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(User User)
        {
            User.ID = GetAll().Count() + 1; // temporary solution
            _context.User.Add(User);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(User User)
        {
            _context.User.Remove(User);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<User> GetAll()
        {
            return [.. _context.User];
        }

        public User? GetByID(int id)
        {
            return _context.User.FirstOrDefault(a => a.ID == id);
        }

        public bool Update(User User)
        {
            _context.User.Update(User);
            return _context.SaveChanges() == 1;
        }
    }
}
