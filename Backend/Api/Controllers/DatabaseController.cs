using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("Database")]
public class DatabaseController(IDatabaseService databaseService) : ControllerBase
{
    private readonly IDatabaseService _databaseService = databaseService;

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
}
