using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IComplaintRepository
    {
        public IEnumerable<Complaint> GetAll();
        public Complaint? GetByID(int id);
        public int Add(Complaint Complaint);
        public bool Update(Complaint Complaint);
        public bool Delete(Complaint Complaint);
    }
}
