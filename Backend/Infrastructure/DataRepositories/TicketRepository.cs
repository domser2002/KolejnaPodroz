using Domain.Common;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataRepositories
{
    public class TicketRepository(DomainDBContext context) : ITicketRepository
    {
        private readonly DomainDBContext _context = context;
        public bool Add(Ticket Ticket)
        {
            int id = !GetAll().Any() ? 1 : GetAll().Max(x => x.ID) +1;
            Ticket.ID = id;
            _context.Ticket.Add(Ticket);
            return _context.SaveChanges() == 1;
        }

        public bool Delete(Ticket Ticket)
        {
            _context.Ticket.Remove(Ticket);
            return _context.SaveChanges() == 1;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return [.. _context.Ticket];
        }

        public Ticket? GetByID(int id)
        {
            return _context.Ticket.FirstOrDefault(a => a.ID == id);
        }

        public bool Update(Ticket Ticket)
        {
            _context.Ticket.Update(Ticket);
            return _context.SaveChanges() == 1;
        }
    }
}
