using Logic.Services.Implementations;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Ranking")]
public class RankingController : ControllerBase
{
    private readonly StatisticsService _rankingService;
    public RankingController(StatisticsService rankingService)
    {
        _rankingService = rankingService;
    }

    [HttpGet("byUser/{userID}")]
    public ActionResult<List<Statistics>> Get(int userID)
    {
        try
        {
            var rankings = _rankingService.GetByUser(userID);
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
            var updated = _rankingService.Update(ranking);
            return updated ? Ok() : NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
