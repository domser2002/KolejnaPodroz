using Logic.Services.Implementations;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Payment")]
public class PaymentController(IPaymentService paymentService) : ControllerBase
{
    private readonly IPaymentService _paymentService = paymentService;

    [HttpPost("process/paymentID")]
    public ActionResult ProcessPayment()
    {
        bool success;
        try
        {
            success = _paymentService.ProceedPayment();
        }
        catch (Exception) 
        {
            return StatusCode(500);
        }
        if(!success) 
        { 
            return BadRequest();
        }
        return Ok();
    }
}
