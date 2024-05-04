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
    public class FakeComplaintRepository : IComplaintRepository
    {
        private readonly List<Complaint> Complaints = [];

        public IEnumerable<Complaint> GetAll()
        {
            return Complaints;
        }

        public Complaint? GetByID(int id)
        {
            return Complaints.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(Complaint Complaint)
        {
            Complaints.Add(Complaint);
            return true;
        }

        public bool Update(Complaint Complaint)
        {
            int index = Complaints.FindIndex(u => u.ID == Complaint.ID);
            if (index != -1)
            {
                Complaints.RemoveAt(index);
                Complaints.Add(Complaint);
                return true;
            }
            return false;
        }

        public bool Delete(Complaint Complaint)
        {
            return Complaints.Remove(Complaint);
        }
    }
}
