using Domain.Common;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class ComplaintRepository(DomainDBContext context) : IComplaintRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(Complaint Complaint)
        {
            _context.Complaint.Add(Complaint);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Complaint Complaint)
        {
            _context.Complaint.Remove(Complaint);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Complaint> GetAll()
        {
            return [.. _context.Complaint];
        }

        public Complaint? GetByID(int id)
        {
            return _context.Complaint.FirstOrDefault(a => a.ID == id);
        }

        public bool Update(Complaint Complaint)
        {
            _context.Complaint.Update(Complaint);
            return _context.SaveChanges() == 1;
        }
    }
}
