using Domain.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Train")]
public class TrainController : ControllerBase
{
    private readonly TrainService _trainService;
    public TrainController(TrainService trainService)
    {
        _trainService = trainService;
    }

    [HttpGet("{trainID}")]
    public ActionResult<Train> GetTrainByID(int trainID)
    {
        var train = _trainService.GetTrainByID(trainID);
        return train != null ? Ok(train) : NotFound();
    }

    [HttpPost("Add")]
    public ActionResult AddTrain(Train train)
    {
        var added = _trainService.AddTrain(train);
        return added ? Ok() : BadRequest();
    }

    [HttpPut("Edit")]
    public ActionResult EditTrain(Train train)
    {
        var edited = _trainService.EditTrain(train);
        return edited ? Ok() : BadRequest();
    }
}
