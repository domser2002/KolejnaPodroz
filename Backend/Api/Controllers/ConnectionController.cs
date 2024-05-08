using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using System.Net.Mime;
using Logic.Services.Implementations;

namespace Api.Controllers
{
    [ApiController]
    [Route("Connection")]
    public class ConnectionController(IConnectionService connectionService) : ControllerBase
    {
        private readonly IConnectionService _connectionService = connectionService;

        [HttpPost("add")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Connection))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> MakeConnection([FromBody] Connection newConnection)
        {
            bool success;
            try
            {
                success = _connectionService.AddConnection(newConnection);
            }
            catch (Exception) 
            {
                return StatusCode(500);
            }
            if(!success) 
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetConnectionByID), new { id = newConnection.ID }, newConnection);
        }

        [HttpDelete("remove/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<int> RemoveConnection(int id)
        {
            bool success;
            try
            {
                success = _connectionService.RemoveConnection(id);
            }
            catch(Exception) 
            {
                return StatusCode(500);
            }
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
        public ActionResult<int> EditConnection(Connection newConnection)
        {
            bool success;
            try
            {
                success = _connectionService.EditConnection(newConnection);
            }
            catch(Exception) 
            {
                return StatusCode(500);
            }
            if(!success)
            {
                return BadRequest();
            }
            return Ok($"Connection {newConnection.ID} has been succesfully edited!");
        }
        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Connection))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetConnectionByID(int id)
        {
            Connection? result;
            try
            {
                result = _connectionService.GetConnectionByID(id);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("searchConnections")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Connection>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int>SearchConnections(string from, string to, DateTime when)
        {
            List<Connection>? result;
            try
            {
                result = _connectionService.SearchConnections(from, to, when);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
