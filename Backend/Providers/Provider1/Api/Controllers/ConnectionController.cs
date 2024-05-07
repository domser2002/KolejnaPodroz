using Domain.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Api.Controllers;

[ApiController]
[Route("Connection")]
public class ConnectionController : ControllerBase
{
    private readonly ConnectionService _connectionService;
    private readonly JsonSerializerOptions _options;
    public ConnectionController(ConnectionService connectionService)
    {
        _connectionService = connectionService;
        _options = new() { IncludeFields = true };
    }

    [HttpGet("{connectionID}")]
    public ActionResult<Connection> GetConnectionByID(int connectionID)
    {
        var connection = _connectionService.GetConnectionByID(connectionID);
        return connection != null ? Ok(JsonSerializer.Serialize(connection, _options)) : NotFound();
    }

    [HttpPut("Edit")]
    public ActionResult EditConnection(Connection connection)
    {
        var edited = _connectionService.EditConnection(connection);
        return edited ? Ok() : NotFound();
    }
}
