using Api.Services;
using Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("AccountInfo")]
    public class AccountInfoController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountInfoController(AccountService accountService) 
        {
            _accountService = accountService;
        }

        [HttpGet("{userId}")]
        public ActionResult<AccountInfo> GetInfoByUserId(int userId)
        {
            try
            {
                var accountInfo = _accountService.GetAccountInfo(userId);

                if (accountInfo == null)
                    return NotFound();

                return Ok(accountInfo);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{userId}")]
        public ActionResult UpdateAccountInfo(int userId, AccountInfo accountInfo)
        {
            try
            {
                bool updated = _accountService.UpdateAccountInfo(userId, accountInfo);

                return updated ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
