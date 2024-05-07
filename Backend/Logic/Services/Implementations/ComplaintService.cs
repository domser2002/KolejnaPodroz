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
    public void EditComplaint(int complaintID, Complaint newComplaint)
    {
        Complaint? complaint = _repository.ComplaintRepository.GetByID(complaintID);
        if (complaint != null)
        {
            _repository.ComplaintRepository.Delete(complaint);
            // perform edition
            _repository.ComplaintRepository.Add(newComplaint);
        }
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
