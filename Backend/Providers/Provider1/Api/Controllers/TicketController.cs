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
        private readonly JourneyService _journeyService;
        public TicketController(TicketService ticketService, JourneyService journeyService)
        {
            _ticketService = ticketService;
            _journeyService = journeyService;
        }

        [HttpGet("{ticketID}")]
        public ActionResult<Ticket> GetTicketByID(int ticketID)
        {
            var ticket = _ticketService.GetTicketByID(ticketID);
            return ticket != null ? Ok(ticket) : NotFound();
        }

        [HttpPost("Add")]
        public ActionResult AddTicket(AddTicketRequest request)
        {
            var ticket = new Ticket
            {
                JourneyID = request.JourneyID,
                StartStationID = request.StartStationID,
                EndStationID = request.EndStationID,
                SeatNumber = request.seatNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone
            };

            var journey = _journeyService.GetJourneyByID(ticket.JourneyID);
            if (journey == null)
            {
                return BadRequest();
            }

            var seat = journey.Seats?.Find(s => s.Number == ticket.SeatNumber);
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
            
            return added ? Ok() : BadRequest();
        }
        [HttpPut("Edit")]
        public ActionResult EditTicket(Ticket ticket)
        {
            var edited = _ticketService.EditTicket(ticket);
            return edited ? Ok() : BadRequest();
        }
    }
}
