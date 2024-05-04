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
    public class FakeTicketRepository : ITicketRepository
    {
        private readonly List<Ticket> Tickets = [];

        public IEnumerable<Ticket> GetAll()
        {
            return Tickets;
        }

        public Ticket? GetByID(int id)
        {
            return Tickets.FirstOrDefault(a => a.ID == id);
        }

        public bool Add(Ticket Ticket)
        {
            Tickets.Add(Ticket);
            return true;
        }

        public bool Update(Ticket Ticket)
        {
            int index = Tickets.FindIndex(u => u.ID == Ticket.ID);
            if (index != -1)
            {
                Tickets.RemoveAt(index);
                Tickets.Add(Ticket);
                return true;
            }
            return false;
        }

        public bool Delete(Ticket Ticket)
        {
            return Tickets.Remove(Ticket);
        }
    }
}
