using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Provider")]
    public class ProviderController : ControllerBase
    {
        [HttpGet("{providerId}")]
        public OkResult GetProviderById()
        {
            return Ok();
        }
    }
}
