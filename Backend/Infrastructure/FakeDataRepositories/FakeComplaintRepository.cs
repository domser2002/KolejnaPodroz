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
        private static int nextID = 3;
        public FakeComplaintRepository() 
        {
            Complaint complaint1 = new Complaint();
            complaint1.ID = 1;
            complaint1.Title = "Jestem zdenerwowany!!!";
            complaint1.Content = "Scrollowanie mi nie dziala";
            complaint1.Response = "To wina myszki";
            complaint1.IsResponded = true;

            Complaint complaint2 = new Complaint();
            complaint2.ID = 2;
            complaint2.Title = "Wybor jest za duzy";
            complaint2.Content = "Ta aplikacja ma tyle pociagow, ze ciezko sie zdecydowac";
            complaint2.Response = "...";
            complaint2.IsResponded = false;

            Complaints.Add(complaint1);
            Complaints.Add(complaint2);
        }

        public IEnumerable<Complaint> GetAll()
        {
            return Complaints;
        }

        public Complaint? GetByID(int id)
        {
            return Complaints.FirstOrDefault(a => a.ID == id);
        }

        public int Add(Complaint Complaint)
        {
            Complaint.ID = nextID++;
            Complaints.Add(Complaint);
            return Complaint.ID;
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
