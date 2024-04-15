using Api.Services;
using Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ticket")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;
        public TicketController(TicketService ticketService) 
        {
            _ticketService = ticketService;
        }

        [HttpGet("{ticketId}")]
        public ActionResult<Ticket> GetTicketById(int ticketId)
        {
            try
            {
                var ticket = _ticketService.GetTicketById(ticketId);
                return ticket != null ? Ok(ticket) : NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("byUser/{ticketId}")]
        public ActionResult<List<Ticket>> GetTicketByUserId(int userId)
        {
            try
            {
                var tickets = _ticketService.ListByUser(userId);
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
                var ticketId = _ticketService.Add(ticket);
                return ticketId != null ? Ok(ticketId) : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpPut("edit")]
        public ActionResult EditTicket(Ticket ticket)
        {
            try
            {
                bool edited = _ticketService.ChangeDetails(ticket);
                return edited ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
