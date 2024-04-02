using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("AccountInfo")]
    public class AccountInfoController : ControllerBase
    {
        [HttpGet("{userId}")]
        public OkResult GetInfoByUserId()
        {
            return Ok();
        }
    }
}
