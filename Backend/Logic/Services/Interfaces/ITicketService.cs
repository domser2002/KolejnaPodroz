using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Interfaces
{
    public interface ITicketService
    {
        public bool Buy(Ticket ticket);
        public List<Ticket> ListByUser(int userID);
        public void Generate(Ticket ticket);
        public bool Remove(int ticketID);
        public int Add(Ticket? ticket);
        public bool ChangeDetails(int ticketId, Ticket ticket);
        public Ticket? GetTicketByID(int ticketID);
        public double GetPrice(int ticketID);
    }
}
