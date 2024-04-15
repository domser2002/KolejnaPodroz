using Api.Services;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ranking")]
    public class RankingController : ControllerBase
    {
        private readonly RankingService _rankingService;
        public RankingController(RankingService rankingService)
        {
            _rankingService = rankingService;
        }

        [HttpGet("byUser/{userId}")]
        public ActionResult<List<Ranking>> Get(int userId)
        {
            try
            {
                var rankings = _rankingService.GetByUser(userId);
                return rankings == null ? Ok(rankings) : NotFound();
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("update/byUser/{userId}")]
        public ActionResult Update(int userId, Ranking ranking)
        {
            try
            {
                var updated = _rankingService.Update(userId, ranking);
                return updated ? Ok() : NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
