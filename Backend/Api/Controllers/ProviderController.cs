using Logic.Services.Implementations;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Provider")]
public class ProviderController : ControllerBase
{
    public readonly ProviderService _providerService;
    public ProviderController(ProviderService providerService)
    {
        _providerService = providerService;
    }

    [HttpGet("{providerID}")]
    public ActionResult<Provider> GetProviderByID(int providerID)
    {
        try
        {
            var provider = _providerService.GetProviderByID(providerID);
            return provider != null ? Ok(provider) : NotFound();
        }
        catch(Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPost("add/{providerID}")]
    public ActionResult AddProvider(Provider provider)
    {
        try
        {
            var added = _providerService.AddProvider(provider);
            return added ? Ok() : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut("edit")]
    public ActionResult EditProvider(Provider provider)
    {
        try
        {
            var edited = _providerService.EditProvider(provider);
            return edited ? Ok() : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete("delete/{providerID}")]
    public ActionResult RemoveProvider(int providerID)
    {
        try
        {
            var removed = _providerService.RemoveProvider(providerID);
            return removed ? Ok() : BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
