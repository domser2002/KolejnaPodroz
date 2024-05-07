using Domain.Models;
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

    [HttpPut("Edit")]
    public ActionResult EditConnection(Connection connection)
    {
        var edited = _connectionService.EditConnection(connection);
        return edited ? Ok() : NotFound();
    }
}
