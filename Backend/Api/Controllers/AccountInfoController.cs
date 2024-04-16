using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("AccountInfo")]
    public class AccountInfoController : ControllerBase
    {
        //private readonly AccountService _accountService;

        public AccountInfoController() { }

        [HttpGet("{userId}")]
        public OkResult GetInfoByUserId()
        {
            return Ok();
        }
    }
}
