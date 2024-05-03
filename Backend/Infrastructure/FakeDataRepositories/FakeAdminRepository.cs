using Domain.Admin;
using Domain.User;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.FakeDataRepositories
{
    public class FakeAdminRepository : IAdminRepository
    {
        private readonly List<Admin> Admins = [];

        public IEnumerable<Admin> GetAll()
        {
            return Admins;
        }

        public Admin? GetByID(int id)
        {
            return Admins.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(Admin Admin)
        {
            Admins.Add(Admin);
            return true;
        }

        public bool Update(Admin Admin)
        {
            int index = Admins.FindIndex(u => u.ID == Admin.ID);
            if (index != -1)
            {
                Admins.RemoveAt(index);
                Admins.Add(Admin);
                return true;
            }
            return false;
        }

        public bool Delete(Admin Admin)
        {
            return Admins.Remove(Admin);
        }
    }
}
