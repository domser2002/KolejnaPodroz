using Domain.Common;
using Logic.Services.Implementations;

namespace Test
{
    public class ComplaintServiceTests
    {
        ComplaintService _complaintService;
        [SetUp]
        public void Setup()
        {
            _complaintService = new ComplaintService(new Domain.Common.DomainDBContext());
        }

        [Test]
        public void CanReturn_MakeComplaint_ReturnsTrue() 
        {
            // Arrange
            Complaint complaint = new();
            // Act
            _complaintService.MakeComplaint(complaint);
            Complaint complaint1 = _complaintService.GetComplaintByID(complaint.ID);
            // Assert
            Assert.AreEqual(complaint, complaint1);
        }

        [Test]
        public void CanReturn_MakeComplaint_ReturnsFalse()
        {
            // Arrange
            Complaint complaint = null;
            // Act
            bool returnValue = _complaintService.MakeComplaint(complaint);
            // Assert
            Assert.AreEqual(false, returnValue);
        }

        [Test]
        public void CanReturn_RemoveComplaint_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            // Act
            bool returnValue = _complaintService.RemoveComplaint(id);
            // Assert
            Assert.AreEqual(true, returnValue);
        }

        [Test]
        public void CanReturn_RemoveComplaint_ReturnsFalse()
        {
            // Arrange
            int id = -1;
            // Act
            bool returnValue = _complaintService.RemoveComplaint(id);
            // Assert
            Assert.AreEqual(false, returnValue);
        }

        [Test]
        public void CanExecute_EditComplaint_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            // Act
            _complaintService.EditComplaint(id);
            // Assert
            //Assert.DoesNotThrow(Exception );
        }

    }
}
