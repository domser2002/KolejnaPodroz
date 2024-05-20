using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IConnectionRepository
    {
        public IEnumerable<Connection> GetAll();
        public Connection? GetByID(int id);
        public int Add(Connection Complaint);
        public bool Update(Connection Complaint);
        public bool Delete(Connection Complaint);
    }
}
