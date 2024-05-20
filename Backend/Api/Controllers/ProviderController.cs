using Logic.Services.Implementations;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Logic.Services.Interfaces;
using System.Net.Mime;

namespace Api.Controllers;

[ApiController]
[Route("Provider")]
public class ProviderController(IProviderService providerService) : ControllerBase
{
    private readonly IProviderService _providerService = providerService;

    [HttpGet("get/{providerID}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Provider))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [HttpPost("add")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Provider))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Provider> MakeProvider([FromBody] Provider newProvider)
    {
        int return_id;
        try
        {
            return_id = _providerService.AddProvider(newProvider);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
        if (return_id == -1)
        {
            return BadRequest();
        }
        newProvider.ID = return_id;
        return Ok(newProvider);
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
