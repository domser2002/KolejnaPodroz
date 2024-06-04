using Domain.Common;
using Logic.Services.Decorators;
using Logic.Services.Implementations;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("Payment")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public ActionResult ProcessPayment([FromBody] Payment payment)
        {
            bool success;
            try
            {
                success = _paymentService.ProceedPayment(payment);
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            if (!success)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
