using Domain.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAdminRepository
    {
        public IEnumerable<Admin> GetAll();
        public Admin? GetByID(int id);
        public int Add(Admin Admin);
        public bool Update(Admin Admin);
        public bool Delete(Admin Admin);
    }
}
