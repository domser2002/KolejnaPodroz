using Logic.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Payment")]
public class PaymentController(PaymentService paymentService) : ControllerBase
{
    private readonly PaymentService _paymentService = paymentService;

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
