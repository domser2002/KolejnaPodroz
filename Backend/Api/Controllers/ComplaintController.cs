using Logic.Services.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Azure.Core;

namespace Api.Controllers;

[ApiController]
[Route("Complaint")]
public class ComplaintController(IComplaintService complaintService) : ControllerBase
{
    private readonly IComplaintService _complaintService = complaintService;

    [HttpPost("make")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Complaint))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<int> MakeComplaint([FromBody] Complaint newComplaint)
    {
        bool success;
        try
        {
            success = _complaintService.MakeComplaint(newComplaint);
        }
        catch (Exception) 
        {
            return StatusCode(500);
        }
        if(!success)
        {
            return BadRequest();
        }
        return CreatedAtAction(nameof(GetComplaintByID), new { id = newComplaint.ID }, newComplaint);
    }

    [HttpDelete("remove/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<int> RemoveComplaint(int id)
    {
        bool success;
        try
        {
            success = _complaintService.RemoveComplaint(id);
        }
        catch(Exception) 
        {
            return StatusCode(500);
        }
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
    public ActionResult<int> EditComplaint(Complaint newComplaint)
    {
        bool success;
        try
        {
            success = _complaintService.EditComplaint(newComplaint);
        }
        catch(Exception)
        {
            return StatusCode(500);
        }
        if(!success)
        {
            return NotFound();
        }
        return Ok($"Complaint {newComplaint.ID} has been succesfully edited!");
    }
    [HttpGet("get/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Complaint))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult GetComplaintByID(int id)
    {
        Complaint? result;
        try
        {
            result = _complaintService.GetComplaintByID(id);
        }
        catch(Exception)
        {
            return StatusCode(500);
        }
        if (result is null)
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
        List<Complaint> result;
        try
        {
            result = _complaintService.GetComplaintsByUserID(userID);
        }
        catch(Exception) 
        {
            return StatusCode(500);
        }
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}
