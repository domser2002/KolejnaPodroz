using ProviderDomain.Models;
using ProviderLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProviderApi.Controllers;

[ApiController]
[Route("Station")]
public class StationController : ControllerBase
{
    private readonly StationService _stationService;
    public StationController(StationService stationService)
    {
        _stationService = stationService;
    }

    [HttpGet("{stationID}")]
    public ActionResult<Station> GetStationByID(int stationID)
    {
        var station = _stationService.GetStationByID(stationID);
        return station != null ? Ok(station) : NotFound();
    }
}
