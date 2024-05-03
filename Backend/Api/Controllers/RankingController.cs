using Logic.Services.Implementations;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Ranking")]
public class RankingController : ControllerBase
{
    private readonly RankingService _rankingService;
    public RankingController(RankingService rankingService)
    {
        _rankingService = rankingService;
    }

    [HttpGet("byUser/{userID}")]
    public ActionResult<List<Ranking>> Get(int userID)
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
    public ActionResult Update(int userID, Ranking ranking)
    {
        try
        {
            var updated = _rankingService.Update(userID, ranking);
            return updated ? Ok() : NotFound();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
