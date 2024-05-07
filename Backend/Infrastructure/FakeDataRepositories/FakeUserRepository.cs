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

        /*
        */
        public FakeUserRepository() 
        {
            User user1 = new User();
            user1.ID = 1;
            user1.FirstName = "Mariusz";
            user1.LastName = "Zurek";
            user1.Email = "m.zurek@gmail.com";
            user1.BirthDate = new DateTime(year:1995, month:9, day:20);
            user1.PreferedSeatType = Domain.Enums.SeatType.Compartmentless;
            user1.PreferedSeatLocation = Domain.Enums.SeatLocation.Corridor;

            User user2 = new User();
            user2.ID = 2;
            user2.FirstName = "Klaudia";
            user2.LastName = "Rura";
            user2.Email = "ruraklaudia@onet.eu";
            user2.BirthDate = new DateTime(year: 2000, month: 3, day: 14);
            user2.PreferedSeatType = Domain.Enums.SeatType.Compartment;
            user2.PreferedSeatLocation = Domain.Enums.SeatLocation.Window;

            Users.Add(user1);
            Users.Add(user2);
        }

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
