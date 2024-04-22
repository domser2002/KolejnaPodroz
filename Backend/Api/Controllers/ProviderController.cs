using Logic.Services.Implementations;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Provider")]
    public class ProviderController : ControllerBase
    {
        public readonly ProviderService _providerService;
        public ProviderController(ProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet("{providerId}")]
        public ActionResult<Provider> GetProviderById(int providerId)
        {
            try
            {
                var provider = _providerService.GetProviderById(providerId);
                return provider != null ? Ok(provider) : NotFound();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("add/{providerId}")]
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

        [HttpPut("edit/{providerId}")]
        public ActionResult EditProvider(int providerId, Provider provider)
        {
            try
            {
                var edited = _providerService.EditProvider(providerId, provider);
                return edited ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{providerId}")]
        public ActionResult RemoveProvider(int providerId)
        {
            try
            {
                var removed = _providerService.RemoveProvider(providerId);
                return removed ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
