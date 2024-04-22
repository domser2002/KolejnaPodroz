using Domain.Common;

namespace Logic.Services.Implementations;

public class ComplaintService : Interfaces.IComplaintService
{
    DomainDBContext ddbContext;
    public ComplaintService(DomainDBContext dbContext) 
    {
        ddbContext = dbContext;
    }
    public bool MakeComplaint(Complaint complaint)
    {
        ddbContext.Complaint.Add(complaint);
        if(ddbContext.SaveChanges() != 1) return false;
        return true;
    }
    public bool RemoveComplaint(int complaintID)
    {
        Complaint complaint = ddbContext.Complaint.Find(complaintID);
        ddbContext.Complaint.Remove(complaint);
        if (ddbContext.SaveChanges() != 1) return false;
        return true;
    }
    public void EditComplaint(int complaintID)
    {
        Complaint complaint = ddbContext.Complaint.Find(complaintID);
        ddbContext.Complaint.Remove(complaint);
        // perform edition
        ddbContext.Complaint.Add(complaint);
        ddbContext.SaveChanges();
    }
    public Complaint GetComplaintByID(int complaintID)
    {
        return ddbContext.Complaint.Find(complaintID);
    }
    public List<Complaint> GetComplaintsByUserID(int complaintUserID)
    {
        return ddbContext.Complaint.Where(c => c.UserID == complaintUserID).ToList();

    }
}
