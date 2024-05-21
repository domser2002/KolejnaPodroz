using Domain.Common;
using Logic.Services.Implementations;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Payment")]
public class PaymentController(IPaymentService paymentService) : ControllerBase
{
    private readonly IPaymentService _paymentService = paymentService;

    [HttpPost("process")]
    public ActionResult ProcessPayment([FromBody] Payment payment)
    {
        bool success;
        try
        {
            success = _paymentService.ProceedPayment(payment);
        }
        catch (Exception) 
        {
            return BadRequest();
        }
        if(!success) 
        { 
            return BadRequest();
        }
        return Ok();
    }
}
