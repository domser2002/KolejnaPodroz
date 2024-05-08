using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Interfaces;

namespace Logic.Services.Implementations;

public class TicketService(IDataRepository repository) : ITicketService
{
    private readonly IDataRepository _repository = repository;
    public bool Buy(Ticket ticket)
    {
        ticket.Purchased = true;
        _repository.TicketRepository.Update(ticket);
        return true;
    }
    public List<Ticket> ListByUser(int userID)
    {
        return _repository.TicketRepository.GetAll().Where(t => t.OwnerID == userID).ToList();
    }
    public void Generate(Ticket ticket)
    {
        throw new NotImplementedException();
    }
    public bool Remove(int ticketID)
    {
        Ticket? ticket = _repository.TicketRepository.GetByID(ticketID);
        if (ticket == null) return false;
        _repository.TicketRepository.Delete(ticket);
        return true;
    }
    public bool Add(Ticket ticket)
    {
        _repository.TicketRepository.Add(ticket);
        return true;
        // return ticketID
    }
    public bool ChangeDetails(int ticketID, Ticket newTicket)
    {
        Ticket? ticket = _repository.TicketRepository.GetByID(ticketID);
        if(ticket != null)
        {
            _repository.TicketRepository.Delete(ticket);
            _repository.TicketRepository.Add(newTicket);
            return true;
        }
        return false;
    }
    public Ticket? GetTicketByID(int ticketID)
    {
        return _repository.TicketRepository.GetByID(ticketID);
    }
}
