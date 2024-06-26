﻿using Logic.Services.Implementations;
using Domain.Admin;
using Microsoft.AspNetCore.Mvc;
using Logic.Services.Interfaces;
using Domain.Common;
using System;
using System.Net.Mime;
using Domain.User;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<Admin> MakeAdmin([FromBody] Admin newAdmin)
        {
            int return_id;
            try
            {
                return_id = _adminService.CreateAdminAccount(newAdmin);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            if (return_id == -1)
            {
                return BadRequest();
            }
            newAdmin.ID = return_id;
            return Ok(newAdmin);
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

        [HttpPost("accept/{adminID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AcceptAdminAccount(int adminID)
        {
            try
            {
                var verified = _adminService.AcceptNewAdmin(adminID);
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
        [HttpDelete("deleteUserByID/{userID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType (StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<int> deleteUserByID(int userID)
        {
            try
            {
                var removed = _adminService.RemoveUserByID(userID);
                return removed ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("getAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllUsers()
        {
            try
            {
                var users = _adminService.GetAllUsers();
                if(users == null)
                    return BadRequest();
                return Ok(users);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("getAllAdmins")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllAdmins()
        {
            try
            {
                var users = _adminService.GetAllAdmins();
                if (users == null)
                    return BadRequest();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpGet("getAllProviders")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetAllProviders()
        {
            try
            {
                var users = _adminService.GetAllProviders();
                if (users == null)
                    return BadRequest();
                return Ok(users);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("editUser")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<User> EditUser([FromBody] EditUser editedUser)
        {
            try
            {
                var result = _adminService.EditUser(editedUser);
                if (result)
                {
                    var updatedUser = _adminService.GetUserByID(editedUser.Id);
                    return Ok(updatedUser);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("beginTechnicalBreak")]
        public ActionResult StartTechnicalBreak()
        {
            try
            {
                bool res = _adminService.StartTechnicalBreak();
                if (res)
                {
                    return StatusCode(200);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception) 
            {
                return StatusCode(500);
            }
        }
        
        [HttpPatch("stopTechnicalBreak")]
        public ActionResult StopTechnicalBreak() 
        {
            try
            {
                bool res = _adminService.StopTechnicalBreak();
                if (res)
                {
                    return StatusCode(200);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("isTechnicalBreak")]
        public ActionResult<bool> IsTechnicalBreak()
        {
            try
            {
                bool res = _adminService.IsTechnicalBreak();
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
