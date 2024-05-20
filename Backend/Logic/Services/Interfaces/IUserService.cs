using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IUserService
    {
        public int CreateUserAccount(User? user);
        public bool RemoveUserAccount(int userID);
        public bool VerifyUserAccount(int userID);
        public User? AuthoriseUser(string firebaseID, string token);
        public User? GetUserByID(int userID);
    }
}
