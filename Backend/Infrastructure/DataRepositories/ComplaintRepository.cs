using Domain.Common;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public int Add(Complaint Complaint)
        {
            int id = !GetAll().Any() ? 1 : GetAll().Max(x => x.ID) + 1;
            Complaint.ID = id; // temporary solution
            _context.Complaint.Add(Complaint);
            return (_context.SaveChanges() == 1) ? id : -1;
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

        public bool Update(Complaint oldComplaint, Complaint newComplaint)
        {
            _context.Entry(oldComplaint).State = EntityState.Detached;
            _context.Complaint.Update(newComplaint);
            return _context.SaveChanges() == 1;
        }
    }
}
