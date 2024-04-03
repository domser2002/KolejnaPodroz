using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ticket")]
    public class TicketController : ControllerBase
    {
        [HttpGet("{ticketId}")]
        public OkResult GetTicketById()
        {
            return Ok();
        }
    }
}
