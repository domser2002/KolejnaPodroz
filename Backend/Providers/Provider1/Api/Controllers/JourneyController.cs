using Domain.Models;
using Logic.RequestBodies;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Journey")]
public class JourneyController : ControllerBase
{
    private readonly JourneyService _journeyService;
    public JourneyController(JourneyService journeyService)
    {
        _journeyService = journeyService;
    }

    [HttpGet("{journeyID}")]
    public ActionResult<Journey> GetJourneyByID(int journeyID)
    {
        var journey = _journeyService.GetJourneyByID(journeyID);
        return journey != null ? Ok(journey) : NotFound();
    }

    [HttpGet("ByStartIDAndEndID")]
    public ActionResult<Journey> GetJourneyByStartIDAndEndID(GetJourneyByStartIDAndEndIDRequest request)
    {
        var journey = _journeyService.GetJourneysByStartIDAndEndID(request.startID, request.endID);
        return journey != null ? Ok(journey) : NotFound();
    }

    [HttpGet("Filter")]
    public ActionResult<List<Journey>> FilterJourneys(FilterJourneysRequest request)
    {
        var journeys = _journeyService.FilterJourneys(request);
        return journeys != null ? Ok(journeys) : NotFound();
    }

    [HttpPost("Add")]
    public ActionResult AddJourney(Journey journey)
    {
        var added = _journeyService.AddJourney(journey);
        return added ? Ok() : BadRequest();
    }
}
