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
                StartConnectionID = request.startConnectionID,
                EndConnectionID = request.endConnectionID,
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

            if (request.seatNumber != null)
            {
                var startIndex = journey.Connections!.FindIndex(c => c.ID == ticket.StartConnectionID);
                var endIndex = journey.Connections.FindIndex(c => c.ID == ticket.EndConnectionID) - 1;
                if (startIndex == -1 || startIndex >= endIndex)
                {
                    return BadRequest();
                }
                for(int i = startIndex; i <= endIndex; ++i)
                {
                    var seat = journey.Connections[i].Seats!.Find(s => s.Number == request.seatNumber);
                    if(seat == null || seat.Taken)
                    {
                        return BadRequest();
                    }
                    seat.Taken = true;
                }
            }

            SeatType seatType = journey.Seats!.Find(s => s.Number == request.seatNumber)?.SeatType ?? SeatType.Economy;
            ticket.Price = seatType switch
            {
                SeatType.Business => 100,
                SeatType.Economy => 50,
                _ => 75
            };

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
