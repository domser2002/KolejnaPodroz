using Domain.Common;
using Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Complaint")]
    public class ComplaintController : ControllerBase
    {
        [HttpPost("create")]
        public ActionResult<int> CreateComplaint(Complaint complaint)
        {
            return Ok(0);
        }
    }
}
