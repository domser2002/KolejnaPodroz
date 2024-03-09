using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.User
{
    public class User : Base
    {
        public User() { }
        public Ticket? BuyTicket(int ticketID)
        {
            throw new NotImplementedException();
        }
        public List<Ticket> ListTickets()
        {
            throw new NotImplementedException();
        }
        public Ticket? ExchangeTicket(string newName,string newSurname)
        {
            throw new NotImplementedException();
        }
        public bool DropTicket(int ticketID)
        {
            throw new NotImplementedException();
        }
    }
}
