using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ranking")]
    public class RankingController : ControllerBase
    {
        [HttpGet("{categoryId}")]
        public OkResult Get()
        {
            return Ok();
        }
    }
}
