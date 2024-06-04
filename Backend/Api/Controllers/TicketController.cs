using Domain.User;
using Microsoft.AspNetCore.Mvc;
using Logic.Services.Interfaces;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Logic.Services.Decorators;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ticket")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{ticketID}")]
        public ActionResult<Ticket> GetTicketByID(int ticketID)
        {
            try
            {
                var ticket = _ticketService.GetTicketByID(ticketID);
                return ticket != null ? Ok(ticket) : NotFound();
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("byUser/{userID}")]
        public ActionResult<List<Ticket>> GetTicketByUserID(int userID)
        {
            try
            {
                var tickets = _ticketService.ListByUser(userID);
                return tickets != null ? Ok(tickets) : NotFound();
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("price/{ticketID}")]
        public ActionResult<double> GetPriceByTicketID(int ticketID)
        {
            try
            {
                var price = _ticketService.GetPrice(ticketID);
                return Ok(price);
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
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
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
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
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
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
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
