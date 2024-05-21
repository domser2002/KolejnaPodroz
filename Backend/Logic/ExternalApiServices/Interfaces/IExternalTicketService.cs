using Domain.User;

namespace Logic.ExternalApiServices.Interfaces;

public interface IExternalTicketService
{
    public Ticket GetTicketById(int id);
    public IEnumerable<Ticket> GetTicketsByUser(int userId);
}
