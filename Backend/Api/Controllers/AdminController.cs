using Logic.Services.Implementations;
using Domain.Admin;
using Microsoft.AspNetCore.Mvc;
using Logic.Services.Interfaces;
using Domain.Common;
using System;
using System.Net.Mime;

namespace Api.Controllers
{
    [ApiController]
    [Route("Admin")]
    public class AdminController(IAdminService adminService) : ControllerBase
    {
        private readonly IAdminService _adminService = adminService;

        [HttpPost("create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Admin))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> CreateAccount([FromBody] Admin admin)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult VerifyAdminAccount(int adminID)
        {
            try
            {
                var verified = _adminService.VerifyAdminAccount(adminID);
                return verified ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("authorise/{firebaseID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Admin> AuthoriseAdmin(string firebaseID, string token)
        {
            try
            {
                var admin = _adminService.AuthoriseAdmin(firebaseID, token);
                return admin is not null ? Ok(admin) : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{adminID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<int> DeleteAccount(int adminID)
        {
            try
            {
                var removed = _adminService.RemoveAdminAccount(adminID);
                return removed ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
