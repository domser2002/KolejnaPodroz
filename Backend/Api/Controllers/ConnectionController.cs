using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Common;
using System.Net.Mime;
using Logic.Services.Implementations;
using Microsoft.AspNetCore.Http;
using System;
using Logic.Services.Decorators;

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
        public ActionResult<Connection> MakeConnection([FromBody] Connection newConnection)
        {
            int return_id;
            try
            {
                return_id = _connectionService.AddConnection(newConnection);
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
            newConnection.ID = return_id;
            return Ok(newConnection);
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
                return BadRequest();
            }
            return Ok($"Connection {newConnection.ID} has been successfully edited!");
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
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
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
        public ActionResult<int> SearchConnections(string from, string to, DateTime when)
        {
            List<Connection>? result;
            try
            {
                result = _connectionService.SearchConnections(from, to, when);
            }
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
