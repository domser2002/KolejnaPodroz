﻿using Domain.Common;

namespace Logic.Services.Interfaces;

public interface IComplaintService
{
    public int MakeComplaint(Complaint complaint);
    public bool RemoveComplaint(int complaintID);
    public bool EditComplaint(Complaint newComplaint);
    public Complaint? GetComplaintByID(int complaintID);
    public List<Complaint> GetComplaintsByUserID(int complaintUserID);

    public List<Complaint> GetAllComplaints();
}
