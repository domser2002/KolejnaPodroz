using Api.Services;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Complaint")]
    public class ComplaintController : ControllerBase
    {
        private ComplaintService _complaintService;
        public ComplaintController(ComplaintService complaintService)
        {
            _complaintService = complaintService;
        }

        [HttpPost("create")]
        public ActionResult<int> CreateComplaint(Complaint complaint)
        {
            try
            {
                var added = _complaintService.MakeComplaint(complaint);
                return added ? Ok() : BadRequest();
            }
            catch(Exception) 
            {
                return StatusCode(500);
            }
        }
        [HttpDelete("delete/{complaintId}")]
        public ActionResult DeleteComplaint(int complaintId)
        {
            try
            {
                var removed = _complaintService.RemoveComplaint(complaintId);
                return removed ? Ok() : NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        [HttpPatch("edit/{complaintId}")]
        public ActionResult EditComplaint(int complaintId, Complaint complaint)
        {
            try
            {
                var edited = _complaintService.EditComplaint(complaintId, complaint);
                return edited ? Ok() : NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
