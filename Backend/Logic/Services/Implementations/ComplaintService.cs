using Domain.Common;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services.Implementations;

public class ComplaintService(IDataRepository repository) : Interfaces.IComplaintService
{
    private readonly IDataRepository _repository = repository;

    public int MakeComplaint(Complaint? complaint)
    {
        if(complaint == null) return -1;
        return _repository.ComplaintRepository.Add(complaint);
    }
    public bool RemoveComplaint(int complaintID)
    {
        Complaint? complaint = _repository.ComplaintRepository.GetByID(complaintID);
        if (complaint == null) return false;
        _repository.ComplaintRepository.Delete(complaint);
        return true;
    }
    public bool EditComplaint(Complaint newComplaint)
    {
        Complaint? oldComplaint = _repository.ComplaintRepository.GetByID(newComplaint.ID);
        if (oldComplaint != null)
        {
            return _repository.ComplaintRepository.Update(oldComplaint, newComplaint);
        }
        return false;
    }
    public Complaint? GetComplaintByID(int complaintID)
    {
        return _repository.ComplaintRepository.GetByID(complaintID);
    }
    public List<Complaint> GetComplaintsByUserID(int complaintUserID)
    {
        IEnumerable<Complaint> complaints = _repository.ComplaintRepository.GetAll();
        return complaints.Where(c => c.ComplainantID == complaintUserID).ToList();
    }
    public List<Complaint> GetAllComplaints()
    {
       return _repository.ComplaintRepository.GetAll().ToList();
        
    }
}
