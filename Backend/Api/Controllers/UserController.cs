using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Payment")]
    public class UserController : ControllerBase
    {
        [HttpGet("{userId}")]
        public OkResult GetTicketById()
        {
            return Ok();
        }
    }
}
