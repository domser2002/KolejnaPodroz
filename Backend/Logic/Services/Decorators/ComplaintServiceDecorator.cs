using Logic.Services.Interfaces;
using Domain.Common;
using System;

namespace Logic.Services.Decorators
{
    public class ComplaintServiceDecorator : IComplaintService
    {
        private readonly IComplaintService _innerComplaintService;
        private readonly IAdminService _adminService;

        public ComplaintServiceDecorator(IComplaintService innerComplaintService, IAdminService adminService)
        {
            _innerComplaintService = innerComplaintService ?? throw new ArgumentNullException(nameof(innerComplaintService));
            _adminService = adminService ?? throw new ArgumentNullException(nameof(adminService));
        }

        public int MakeComplaint(Complaint complaint)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerComplaintService.MakeComplaint(complaint);
        }

        public bool RemoveComplaint(int complaintID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerComplaintService.RemoveComplaint(complaintID);
        }

        public bool EditComplaint(Complaint newComplaint)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerComplaintService.EditComplaint(newComplaint);
        }

        public Complaint GetComplaintByID(int complaintID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerComplaintService.GetComplaintByID(complaintID);
        }

        public List<Complaint> GetComplaintsByUserID(int complaintUserID)
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerComplaintService.GetComplaintsByUserID(complaintUserID);
        }

        public List<Complaint> GetAllComplaints()
        {
            if (!CheckCondition())
            {
                throw new TechnicalBreakException("Technical Break");
            }

            return _innerComplaintService.GetAllComplaints();
        }

        private bool CheckCondition()
        {
            return !_adminService.IsTechnicalBreak();
        }
    }
}
