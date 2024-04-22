using Logic.Services.Implementations;
using Domain.Admin;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Admin")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("create")]
        public ActionResult CreateAccount(Admin admin)
        {
            try
            {
                var created = _adminService.CreateAdminAccount(admin);
                return created ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPost("verify/{adminID}")]
        public ActionResult VerifyAdminAccount(int adminID)
        {
            try
            {
                var verified = _adminService.VerifyAdminAccount(adminID);
                return verified ? Ok() : BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost("authorise/{adminID}")]
        public ActionResult AuthoriseAdmin(int adminID)
        {
            try
            {
                var authorised = _adminService.AuthoriseAdmin(adminID);
                return authorised ? Ok() : BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("delete/{adminID}")]
        public ActionResult DeleteAccount(int adminID)
        {
            try
            {
                var removed = _adminService.RemoveAdminAccount(adminID);
                return removed ? Ok() : BadRequest();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
