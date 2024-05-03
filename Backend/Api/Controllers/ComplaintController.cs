using Logic.Services.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Api.Controllers;

[ApiController]
[Route("Complaint")]
public class ComplaintController : ControllerBase
{
    private readonly IComplaintService _complaintService;

    public ComplaintController(IComplaintService complaintService)
    {
        _complaintService = complaintService;
    }

    [HttpPost("make")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Complaint))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<int> MakeComplaint([FromBody] Complaint newComplaint)
    {
        _complaintService.MakeComplaint(newComplaint);
        return CreatedAtAction(nameof(GetComplaintByID), new { id = newComplaint.ID }, newComplaint);
    }

    [HttpDelete("remove/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<int> RemoveComplaint(int id)
    {
        var success = _complaintService.RemoveComplaint(id);
        if(!success)
        {
            return NotFound();
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
