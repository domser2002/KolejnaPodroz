using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ITicketRepository
    {
        public IEnumerable<Ticket> GetAll();
        public Ticket? GetByID(int id);
        public int Add(Ticket Ticket);
        public bool Update(Ticket Ticket);
        public bool Delete(Ticket Ticket);
    }
}
