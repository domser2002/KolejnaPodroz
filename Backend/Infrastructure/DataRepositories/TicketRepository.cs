using Domain.Admin;
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
    public class TicketRepository(DomainDBContext context) : Repository<Ticket>(context), ITicketRepository
    {
    }
}
