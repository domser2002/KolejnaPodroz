using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Payment")]
    public class PaymentController : ControllerBase
    {
        [HttpGet("process/{paymentId}")]
        public OkResult Post()
        {
            return Ok();
        }
    }
}
