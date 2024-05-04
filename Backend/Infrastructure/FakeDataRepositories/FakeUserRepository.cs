using Domain.Common;
using Domain.User;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> Users = [];

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public User? GetByID(int id)
        {
            return Users.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(User User)
        {
            Users.Add(User);
            return true;
        }

        public bool Update(User User)
        {
            int index = Users.FindIndex(u => u.ID == User.ID);
            if (index != -1)
            {
                Users.RemoveAt(index);
                Users.Add(User);
                return true;
            }
            return false;
        }

        public bool Delete(User User)
        {
            return Users.Remove(User);
        }
    }
}
