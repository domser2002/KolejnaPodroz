using Domain.Models;
using System.Runtime.InteropServices;

namespace Logic.Services;

public class TicketService
{
    public List<Ticket> Tickets { get; set; } = new();
    public bool AddTicket(Ticket ticket)
    {
        if (Tickets.Any(Tickets => Tickets.ID == ticket.ID))
        {
            return false;
        }
        Tickets.Add(ticket);
        return true;
    }
    public Ticket? GetTicketByID(int ID)
    {
        return Tickets.FirstOrDefault(t => t.ID == ID);
    }
    public void RemoveTicketByID(int ID)
    {
        Tickets.RemoveAll(t => t.ID == ID);
    }
    public bool EditTicket(Ticket ticket)
    {
        var ticketIndex = Tickets.FindIndex(t => t.ID == ticket.ID);
        if (ticketIndex == -1)
        {
            return false;
        }
        Tickets[ticketIndex] = ticket;
        return true;
    }
}
