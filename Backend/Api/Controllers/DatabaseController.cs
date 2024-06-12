using Infrastructure.Interfaces;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Database")]
public class DatabaseController(IDatabaseService databaseService, IDataRepository repository) : ControllerBase
{
    private readonly IDatabaseService _databaseService = databaseService;
    private readonly IDataRepository Repository = repository;

    [HttpGet("sqlQuery")]
    public ActionResult<List<Object[]>>QueryDatabase(string query)
    {
        try
        {
            var res = _databaseService.ExecuteSQL(query);
            return res != null ? Ok(res) : NotFound();
        }
        catch
        {
            return StatusCode(500);
        }
    }

    [HttpGet("valid")]
    public ActionResult<bool> CheckError()
    {
        try
        {
            Repository.UserRepository.GetAll();
        }
        catch(Exception)
        {
            return Ok(false);
        }
        return Ok(true);
    }
}
