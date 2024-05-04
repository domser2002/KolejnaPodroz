using Logic.Services.Interfaces;
using Domain.Common;
using Domain.User;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

[ApiController]
[Route("Complaint")]
public class ComplaintController : ControllerBase
{
    {
        }
        return NoContent();
    }

    [HttpPatch("edit/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<int> EditComplaint(int id)
    {
        _complaintService.EditComplaint(id);
        return Ok($"Complaint {id} has been succesfully edited!");
    }
    [HttpGet("get/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Complaint))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult GetComplaintByID(int id)
    {
        var result = _complaintService.GetComplaintByID(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet("getByUser/{userID}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Complaint>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult GetComplaintsByUserID(int userID)
    {
        var result = _complaintService.GetComplaintsByUserID(userID);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}
