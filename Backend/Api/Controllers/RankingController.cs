using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using Logic.Services.Decorators;

namespace Api.Controllers
{
    [ApiController]
    [Route("Ranking")]
    public class RankingController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public RankingController(IStatisticsService statisticsService)
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
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
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
            catch (TechnicalBreakException)
            {
                return StatusCode(430);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
