using Domain.Models;
using Logic.RequestBodies;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ticket")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;
        private readonly ConnectionService _connectionService;
        public TicketController(TicketService ticketService, ConnectionService connectionService)
        {
            _ticketService = ticketService;
            _connectionService = connectionService;
        }

        [HttpGet("{ticketID}")]
        public ActionResult<Ticket> GetTicketByID(int ticketID)
        {
            var ticket = _ticketService.GetTicketByID(ticketID);
            return ticket != null ? Ok(ticket) : NotFound();
        }

        [HttpPost("Add")]
        public ActionResult AddTicket(AddTicketRequestToTicket request)
        {
            var ticket = new Ticket
            {
                ConnectionID = request.ConnectionID,
                StartStationID = request.StartStationID,
                EndStationID = request.EndStationID,
                SeatID = request.SeatID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone
            };

            var connection = _connectionService.GetConnectionByID(ticket.ConnectionID);
            if (connection == null)
            {
                return BadRequest();
            }

            var seat = connection.Seats?.Find(s => s.ID == ticket.SeatID);
            if(seat == null || seat.Taken)
            {
                return BadRequest();
            }
            ticket.Price = seat.SeatType switch
            {
                SeatType.Business => 100,
                SeatType.Economy => 50,
                _ => 75
            };
            seat.Taken = true;

            var added = _ticketService.AddTicket(ticket);
            if (!added)
            {
                return BadRequest();
            }

            return Ok();
        }
        [HttpPut("Edit")]
        public ActionResult EditTicket(Ticket ticket)
        {
            var edited = _ticketService.EditTicket(ticket);
            return edited ? Ok() : BadRequest();
        }
    }
}
