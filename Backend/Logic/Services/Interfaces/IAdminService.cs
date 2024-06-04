using Domain.Admin;
using Domain.Common;
using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IAdminService
    {
        public int CreateAdminAccount(Admin admin);
        public bool RemoveAdminAccount(int adminID);
        public bool VerifyAdminAccount(int adminID);
        public bool AcceptNewAdmin(int adminID);
        public Admin? AuthoriseAdmin(string firebaseID, string token);
        public bool GiveAdminPermissions(Admin admin);
        public bool RemoveUserByID(int userID);
        public List<User> GetAllUsers();
        public List<Admin> GetAllAdmins();
        public List<Provider> GetAllProviders();
        public bool EditUser(EditUser editedUser);
        public User? GetUserByID(int userID);
    }
}
