using Logic.Services.Implementations;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Ranking")]
public class RankingController : ControllerBase
{
    private readonly StatisticsService _statisticsService;
    public RankingController(StatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet("byUser/{userID}")]
    public ActionResult<List<Statistics>> Get(int userID)
    {
        try
        {
            var rankings = _statisticsService.GetByUser(userID);
            return rankings != null ? Ok(rankings) : NotFound();
        }
        catch(Exception)
        {
            return StatusCode(500);
        }
    }
    [HttpPut("update/byUser/{userID}")]
    public ActionResult Update(int userID, Statistics ranking)
    {
        try
        {
            var updated = _statisticsService.Update(ranking);
            return updated ? Ok() : NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
