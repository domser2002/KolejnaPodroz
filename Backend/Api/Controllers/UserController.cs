using Domain.Common;
using Domain.User;
using Logic.Services.Decorators;
using Logic.Services.Implementations;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;

namespace Api.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userID}")]
        public ActionResult<User> GetUserByID(int userID)
        {
            try
            {
                var user = _userService.GetUserByID(userID);
                return user != null ? Ok(user) : NotFound();
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> CreateUser([FromBody] User newUser)
        {
            int return_id;
            try
            {
                return_id = _userService.CreateUserAccount(newUser);
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            if (return_id == -1)
            {
                return BadRequest();
            }
            newUser.ID = return_id;
            return Ok(newUser);
        }

        [HttpPost("verify/{userID}")]
        public ActionResult VerifyAccount(int userID)
        {
            try
            {
                var verified = _userService.VerifyUserAccount(userID);
                return verified ? Ok() : BadRequest();
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("authorise/{firebaseID}")]
        public ActionResult<User> AuthoriseUser(string firebaseID, string token)
        {
            try
            {
                var user = _userService.AuthoriseUser(firebaseID, token);
                return user is not null ? Ok(user) : BadRequest();
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete/{userID}")]
        public ActionResult DeleteAccount(int userID)
        {
            try
            {
                var removed = _userService.RemoveUserAccount(userID);
                return removed ? Ok() : BadRequest();
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch("edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> EditUser(User newUser)
        {
            bool success;
            try
            {
                success = _userService.EditUser(newUser);
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            if (!success)
            {
                return NotFound();
            }
            return Ok($"User {newUser.ID} has been successfully edited!");
        }
    }
}
