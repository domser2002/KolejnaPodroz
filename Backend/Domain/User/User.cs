﻿using Domain.Common;

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
        public Ticket? ExchangeTicket(string newName, string newSurname)
        {
            throw new NotImplementedException();
        }
        public bool DropTicket(int ticketID)
        {
            throw new NotImplementedException();
        }
        public bool MakeComplaint(Complaint complaint)
        {
            throw new NotImplementedException();
        }
        public List<Complaint> ListComplaints()
        {
            throw new NotImplementedException();
        }
        // probably will be implemented using json patch document class as argument
        public bool EditComplaint(int complaintID) 
        {
            throw new NotImplementedException(); 
        }
        public bool RemoveComplaint(int complaintID)
        {
            throw new NotImplementedException();
        }
       
        // probably will be implemented using json patch document class as argument
        public bool UpdateAccountInfo()
        {
            throw new NotImplementedException();
        }
      
    }
}
