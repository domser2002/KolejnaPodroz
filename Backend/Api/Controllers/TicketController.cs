using Logic.Services.Implementations;
using Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Ticket")]
public class TicketController(TicketService ticketService) : ControllerBase
{
    private readonly TicketService _ticketService = ticketService;

    [HttpGet("{ticketID}")]
    public ActionResult<Ticket> GetTicketByID(int ticketID)
    {
        try
        {
            var ticket = _ticketService.GetTicketByID(ticketID);
            return ticket != null ? Ok(ticket) : NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet("byUser/{ticketID}")]
    public ActionResult<List<Ticket>> GetTicketByUserID(int userID)
    {
        try
        {
            var tickets = _ticketService.ListByUser(userID);
            return tickets != null ? Ok(tickets) : NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }        
    
    [HttpPost("create")]
    public ActionResult<int> AddTicket(Ticket ticket)
    {
        try
        {
            var success = _ticketService.Add(ticket);
            return success ? Ok(ticket.ID) : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
    
    [HttpPut("edit")]
    public ActionResult EditTicket(int ticketId, Ticket ticket)
    {
        try
        {
            var edited = _ticketService.ChangeDetails(ticketId, ticket);
            return edited ? Ok() : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("delete/{ticketID}")]
    public ActionResult RemoveTicket(int ticketID)
    {
        try
        {
            var removed = _ticketService.Remove(ticketID);
            return removed ? Ok() : NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
