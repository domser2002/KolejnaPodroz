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
        private static int nextID = 1;
        public FakeTicketRepository() 
        {
            Ticket t1 = new Ticket();
            t1.ID = 1;
            t1.OwnerID = 1;
            t1.ConnectionID = 2;

            Ticket t2 = new Ticket();
            t2.ID = 2;
            t2.OwnerID = 2;
            t2.ConnectionID = 2;

            Ticket t3 = new Ticket();
            t3.ID = 3;
            t3.OwnerID = 2;
            t3.ConnectionID = 1;

            Add(t1);
            Add(t2);
            Add(t3);
        }
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
            Ticket.ID = nextID++;
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
