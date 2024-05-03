using Domain.Common;
using Logic.Services.Implementations;
using Infrastructure.FakeDataRepositories;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Microsoft.EntityFrameworkCore;

namespace Test;

public class ComplaintServiceTests
{
    ComplaintService fakeComplaintService;
    ComplaintService complaintService;
    readonly string connectionString = "Server=DESKTOP-OEFV9O5,1433;Initial Catalog=Domain;Persist Security Info=False;User ID=KolejnaPodroz;Password=lubiepociagi123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"; // to be changed when moved to Azure, tests will fail on github
    [SetUp]
    public void Setup()
    {
        fakeComplaintService = new ComplaintService(new FakeDataRepository());
        var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
        optionsBuilder.UseSqlServer(connectionString);
        DataRepository dataRepository = new(new DomainDBContext(optionsBuilder.Options));
        complaintService = new ComplaintService(dataRepository);
    }

    [Test]
    public void CanReturn_MakeComplaint_ReturnsTrue() 
    {
        // Arrange
        Complaint complaint = new();
        // Act
        fakeComplaintService.MakeComplaint(complaint);
        Complaint complaint1 = fakeComplaintService.GetComplaintByID(complaint.ID);
        // Assert
        Assert.AreEqual(complaint, complaint1);
    }

    [Test]
    public void CanReturn_MakeComplaint_ReturnsFalse()
    {
        // Arrange
        Complaint? complaint = null;
        // Act
        bool returnValue = fakeComplaintService.MakeComplaint(complaint);
        // Assert
        Assert.AreEqual(false, returnValue);
    }

    [Test]
    public void CanReturn_RemoveComplaint_ReturnsTrue()
    {
        // Arrange
        int id = 1;
        // Act
        bool returnValue = fakeComplaintService.RemoveComplaint(id);
        // Assert
        Assert.AreEqual(true, returnValue);
    }

    [Test]
    public void CanReturn_RemoveComplaint_ReturnsFalse()
    {
        // Arrange
        int id = -1;
        // Act
        bool returnValue = fakeComplaintService.RemoveComplaint(id);
        // Assert
        Assert.AreEqual(false, returnValue);
    }

    [Test]
    public void CanExecute_EditComplaint_ReturnsTrue()
    {
        // Arrange
        int id = 1;
        // Act
        fakeComplaintService.EditComplaint(id);
        // Assert
        //Assert.DoesNotThrow(Exception );
    }

}
