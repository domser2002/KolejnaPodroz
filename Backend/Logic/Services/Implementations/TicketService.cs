using Domain.User;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class TicketService(IDataRepository repository)
{
    private readonly IDataRepository _repository = repository;
    public bool Buy(Ticket ticket)
    {
        throw new NotImplementedException();
    }
    public List<Ticket> ListByUser(int userID)
    {
        throw new NotImplementedException();
    }
    public void Generate(Ticket ticket)
    {
        throw new NotImplementedException();
    }
    public bool Remove(int ticketID)
    {
        throw new NotImplementedException();
    }
    public bool Add(Ticket ticket)
    {
        throw new NotImplementedException();
        // return ticketID
    }
    public bool ChangeDetails(Ticket ticket)
    {
        throw new NotImplementedException();
    }
    public Ticket? GetTicketByID(int ticketID)
    {
        throw new NotImplementedException();
    }
}
