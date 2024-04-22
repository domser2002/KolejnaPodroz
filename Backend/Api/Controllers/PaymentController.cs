using Logic.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Payment")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        public PaymentController(PaymentService paymentService) 
        {
            _paymentService = paymentService;
        }
        [HttpPost("process/paymentId")]
        public ActionResult ProcessPayment()
        {
            return Ok();
        }
    }
}
