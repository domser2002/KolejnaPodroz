using Domain.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface IAdminService
    {
        public bool CreateAdminAccount(Admin admin);
        public bool RemoveAdminAccount(int adminID);
        public bool VerifyAdminAccount(int adminID);
        public Admin? AuthoriseAdmin(string firebaseID, string token);
        public bool GiveAdminPermissions(Admin admin);
    }
}
