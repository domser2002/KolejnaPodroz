using Domain.Models;
using Logic.RequestBodies;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Connection")]
public class ConnectionController : ControllerBase
{
    private readonly ConnectionService _connectionService;
    public ConnectionController(ConnectionService connectionService)
    {
        _connectionService = connectionService;
    }

    [HttpGet("{connectionID}")]
    public ActionResult<Connection> GetConnectionByID(int connectionID)
    {
        var connection = _connectionService.GetConnectionByID(connectionID);
        return connection != null ? Ok(connection) : NotFound();
    }
    [HttpPost("Add")]
    public ActionResult AddConnection(Connection connection)
    {
        var added = _connectionService.AddConnection(connection);
        return added ? Ok() : BadRequest();
    }
    [HttpGet("ByStartIDAndEndID")]
    public ActionResult<Connection> GetConnectionByStartIDAndEndID(GetConnectionByStartIDAndEndIDRequest request)
    {
        var connection = _connectionService.GetConnectionsByStartIDAndEndID(request.startID, request.endID);
        return connection != null ? Ok(connection) : NotFound();
    }

}
