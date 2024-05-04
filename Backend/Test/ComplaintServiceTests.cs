using Logic.Services.Implementations;
using Infrastructure.DataContexts;
using Infrastructure.FakeDataRepositories;
using Domain.Common;

namespace Test
{
    public class ComplaintServiceTests
    {
        ComplaintService _complaintService;
        [SetUp]
        public void Setup()
        {
            _complaintService = new ComplaintService(new FakeDataRepository());
        }

        [Test]
        public void CanReturn_MakeComplaint_ReturnsTrue() 
        {
        }

        [Test]
        public void CanReturn_MakeComplaint_ReturnsFalse()
        {
        }

        [Test]
        public void CanReturn_RemoveComplaint_ReturnsTrue()
        {
        }

        [Test]
        public void CanReturn_RemoveComplaint_ReturnsFalse()
        {
        }

        [Test]
        public void CanExecute_EditComplaint_ReturnsTrue()
        {
        }

    }
}
