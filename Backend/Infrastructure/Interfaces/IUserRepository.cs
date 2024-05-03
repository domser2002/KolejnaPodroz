using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User? GetByID(int id);
        public bool Add(User user);
        public bool Update(User user);
        public bool Delete(User user);
    }
}
