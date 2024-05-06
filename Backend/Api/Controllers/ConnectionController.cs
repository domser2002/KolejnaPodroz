using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using System.Net.Mime;
using Logic.Services.Implementations;

namespace Api.Controllers
{
    [ApiController]
    [Route("Connection")]
    public class ConnectionController : ControllerBase
    {
        private readonly IConnectionService _connectionService;

        public ConnectionController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        [HttpPost("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Connection))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> MakeConnection([FromBody] Connection newConnection)
        {
            _connectionService.AddConnection(newConnection);
            return CreatedAtAction(nameof(GetConnectionByID), new { id = newConnection.ID }, newConnection);
        }

        [HttpDelete("remove/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> RemoveConnection(int id)
        {
            var success = _connectionService.RemoveConnection(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPatch("edit/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> EditConnection(int id)
        {
            _connectionService.EditConnection(id);
            return Ok($"Connection {id} has been succesfully edited!");
        }
        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Connection))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetConnectionByID(int id)
        {
            var result = _connectionService.GetConnectionByID(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

       
    }
}
