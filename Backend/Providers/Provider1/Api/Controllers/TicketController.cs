using Domain.Models;
using Logic.RequestBodies;
using Logic.ResponseBodies;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ticket")]
    public class TicketController : ControllerBase
    {
        private readonly TicketService _ticketService;
        private readonly JourneyService _journeyService;
        private readonly ConnectionService _connectionService;
        public TicketController(TicketService ticketService, JourneyService journeyService, ConnectionService connectionService)
        {
            _ticketService = ticketService;
            _journeyService = journeyService;
            _connectionService = connectionService;
        }

        [HttpGet("{ticketID}")]
        public ActionResult<Ticket> GetTicketByID(int ticketID)
        {
            var ticket = _ticketService.GetTicketByID(ticketID);
            return ticket != null ? Ok(ticket) : NotFound();
        }

        [HttpPost("Add")]
        public ActionResult<IDResponse> AddTicket(AddTicketRequest request)
        {
            var ticket = new Ticket
            {
                JourneyID = request.journeyID,
                StartConnectionID = request.startConnectionID,
                EndConnectionID = request.endConnectionID,
                SeatNumber = request.seatNumber,
                FirstName = request.firstName,
                LastName = request.lastName,
                Email = request.email,
                Phone = request.phone
            };

            var journey = _journeyService.GetJourneyByID(ticket.JourneyID);
            if (journey == null)
            {
                return BadRequest();
            }

            SeatType seatType = SeatType.Economy;
            if (request.seatNumber != null)
            {
                var startIndex = journey.ConnectionIDs!.FindIndex(cid => cid == ticket.StartConnectionID);
                var endIndex = journey.ConnectionIDs.FindIndex(cid => cid == ticket.EndConnectionID);
                if (startIndex == -1 || startIndex >= endIndex)
                {
                    return BadRequest();
                }
                for(int i = startIndex; i <= endIndex; ++i)
                {
                    var connection = _connectionService.GetConnectionByID(journey.ConnectionIDs[i]);
                    var seat = connection?.Seats?.Find(s => s.Number == request.seatNumber);
                    if(seat == null || seat.Taken)
                    {
                        return BadRequest();
                    }
                    seat.Taken = true;
                    seatType = seat.SeatType;
                }
            }

            ticket.Price = seatType switch
            {
                SeatType.Business => 100,
                SeatType.Economy => 50,
                _ => 75
            };

            var added = _ticketService.AddTicket(ticket);
            return added ? Ok(new AddTicketResponse(ticket.ID, ticket.Price)) : BadRequest();
        }

        [HttpPut("Edit")]
        public ActionResult EditTicket(Ticket ticket)
        {
            var edited = _ticketService.EditTicket(ticket);
            return edited ? Ok() : BadRequest();
        }
    }
}
