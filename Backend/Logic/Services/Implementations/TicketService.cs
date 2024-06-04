using Domain.Common;
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
    public int Add(Ticket? ticket)
    {
        if(ticket is null) return -1;
        User? user = _repository.UserRepository.GetByID(ticket.OwnerID);
        if(user != null)
        {
            user.LoyaltyPoints += 50;
            _repository.UserRepository.Update(user);
        }
        return _repository.TicketRepository.Add(ticket);
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
    public double GetPrice(int ticketID)
    {
        Ticket? ticket = _repository.TicketRepository.GetByID(ticketID);
        if(ticket == null) return 0;
        Connection? connection = _repository.ConnectionRepository.GetByID(ticket.ConnectionID);
        if(connection == null) return 0;
        int count = connection.Stops.Count;
        double price = count * 20;
        User? user = _repository.UserRepository.GetByID(ticket.OwnerID);
        double discountPercentage = 0;
        if (user != null)
        {
            if (user.LoyaltyPoints > 0) discountPercentage += (1000 - (double)1000/user.LoyaltyPoints)*0.02;
        }
        return price - (discountPercentage * price) / 100;
    }
}
