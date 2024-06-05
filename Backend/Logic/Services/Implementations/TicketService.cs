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
        if (ticket is null)
        {
            Console.WriteLine("Ticket is null");
            return -1;
        }

        try
        {
            User? user = _repository.UserRepository.GetByID(ticket.OwnerID);
            if (user != null)
            {
                user.LoyaltyPoints += 50;
                _repository.UserRepository.Update(user);
            }
            else
            {
                Console.WriteLine($"User with ID {ticket.OwnerID} not found.");
            }

            int ticketId = _repository.TicketRepository.Add(ticket);
            return ticketId;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding ticket: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            return -1;
        }
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
        //Connection? connection = _repository.ConnectionRepository.GetByID(ticket.ConnectionID);
        //if(connection == null) return 0;
        //int count = connection.Stops.Count;
        //double price = count * 20;
        double price = 50.0;
        User? user = _repository.UserRepository.GetByID(ticket.OwnerID);
        double discountPercentage = 0;
        if (user != null)
        {
            discountPercentage = (user.LoyaltyPoints > 1000) ? 20 : (user.LoyaltyPoints/50);
        }
        return price - (discountPercentage * price) / 100;
    }
}
