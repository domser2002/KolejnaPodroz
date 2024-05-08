using Domain.Common;
using Infrastructure.Interfaces;

namespace Logic.Services.Implementations;

public class ComplaintService(IDataRepository repository) : Interfaces.IComplaintService
{
    private readonly IDataRepository _repository = repository;

    public bool MakeComplaint(Complaint? complaint)
    {
        if(complaint == null) return false;
        _repository.ComplaintRepository.Add(complaint);
        return true;
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
        Complaint? complaint = _repository.ComplaintRepository.GetByID(newComplaint.ID);
        if (complaint != null)
        {
            return _repository.ComplaintRepository.Update(newComplaint);
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
}
