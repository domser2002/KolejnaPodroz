using Domain.User;
using Logic.Services.Implementations;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("User")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet("{userID}")]
    public ActionResult<User> GetUserByID(int userID)
    {
        try
        {
            var user = _userService.GetUserByID(userID);
            return user != null ? Ok(user) : NotFound();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpPost("create")]
    public ActionResult CreateAccount(User user)
    {
        try
        {
            var created = _userService.CreateUserAccount(user);
            return created ? Ok() : BadRequest();
        }
        catch (Exception) 
        {
            return StatusCode(500);
        }
    }
    [HttpPost("verify/{userID}")]
    public ActionResult VerifyAccount(int userID)
    {
        try
        {
            var verified = _userService.VerifyUserAccount(userID);
            return verified ? Ok() : BadRequest();
        }
        catch
        {
            return StatusCode(500);
        }
    }
    [HttpPost("authorise/{userID}")]
    public ActionResult AuthoriseUser(int userID, string token)
    {
        try
        {
            var authorised = _userService.AuthoriseUser(userID, token);
            return authorised ? Ok() : BadRequest();
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
        catch
        {
            return StatusCode(500);
        }
    }
}
