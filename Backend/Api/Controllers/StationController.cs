using Domain.Common;
using Logic.Services.Decorators;
using Logic.Services.Implementations;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Station")]
    public class StationController(IStationService stationService) : Controller
    {
        private IStationService _stationService = stationService;
        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Station))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetStationByID(int id)
        {
            Station? result;
            try
            {
                result = _stationService.GetByID(id);
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
