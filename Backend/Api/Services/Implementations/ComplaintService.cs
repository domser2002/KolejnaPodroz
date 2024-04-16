using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Implementations
{
    public class ComplaintService : Interfaces.IComplaintService
    {

        public bool MakeComplaint(Complaint complaint)
        {
            throw new NotImplementedException();
        }
        public bool RemoveComplaint(int complaintID)
        {
            throw new NotImplementedException();
        }
        public void EditComplaint(int complaintID)
        {
            throw new NotImplementedException();
        }
        public Complaint GetComplaintByID(int complaintID)
        {
            throw new NotImplementedException();
        }
        public List<Complaint> GetComplaintsByUserID(int complaintUserID)
        {
            throw new NotImplementedException();
        }
    }
}
