using Logic.Services.Implementations;
using Domain.User;
using Microsoft.AspNetCore.Mvc;
using Logic.Services.Interfaces;
using Domain.Common;
using System.Net.Mime;

namespace Api.Controllers;

[ApiController]
[Route("Ticket")]
public class TicketController(ITicketService ticketService) : ControllerBase
{
    private readonly ITicketService _ticketService = ticketService;

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
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Ticket))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Ticket> MakeTicket([FromBody] Ticket newTicket)
    {
        int return_id;
        try
        {
            return_id = _ticketService.Add(newTicket);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
        if (return_id == -1)
        {
            return BadRequest();
        }
        newTicket.ID = return_id;
        return Ok(newTicket);
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
