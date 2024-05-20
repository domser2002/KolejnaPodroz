using Domain.Common;
using Logic.Services.Implementations;
using Infrastructure.FakeDataRepositories;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.User;

namespace Test;

public class ComplaintServiceTests
{
    ComplaintService fakeComplaintService;
    ComplaintService complaintService;
    UserRepository userRepository;
    string? connectionString;
    [SetUp]
    public void Setup()
    {
        fakeComplaintService = new ComplaintService(new FakeDataRepository());
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.Build();
        connectionString = configurationRoot.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
        optionsBuilder.UseSqlServer(connectionString);
        DataRepository dataRepository = new(new DomainDBContext(optionsBuilder.Options));
        userRepository = new(new DomainDBContext(optionsBuilder.Options));
        complaintService = new ComplaintService(dataRepository);
    }

    [Test]
    public void CanReturn_MakeComplaint_ReturnsTrue_UnitTest() 
    {
        // Arrange
        Complaint complaint = new();
        // Act
        fakeComplaintService.MakeComplaint(complaint);
        Complaint? complaint1 = fakeComplaintService.GetComplaintByID(complaint.ID);
        // Assert
        Assert.That(complaint1, Is.EqualTo(complaint));
    }

    [Test]
    public void CanReturn_MakeComplaint_ReturnsFalse_UnitTest()
    {
        // Arrange
        Complaint? complaint = null;
        // Act
        var returnValue = fakeComplaintService.MakeComplaint(complaint);
        // Assert
        Assert.That(returnValue, Is.EqualTo(-1));
    }

    [Test]
    public void CanReturn_RemoveComplaint_ReturnsTrue_UnitTest()
    {
        // Arrange
        Complaint complaint = new();
        complaint.ID = fakeComplaintService.MakeComplaint(complaint);
        // Act
        var returnValue = fakeComplaintService.RemoveComplaint(complaint.ID);
        // Assert
        Assert.That(returnValue, Is.EqualTo(true));
    }

    [Test]
    public void CanReturn_RemoveComplaint_ReturnsFalse_UnitTest()
    {
        // Arrange
        int id = -1;
        // Act
        bool returnValue = fakeComplaintService.RemoveComplaint(id);
        // Assert
        Assert.That(returnValue, Is.EqualTo(false));
    }

    // edit complaint must be refactored
    //[Test]
    //public void CanExecute_EditComplaint_ReturnsTrue()
    //{
    //    // Arrange
    //    int id = 1;
    //    // Act
    //    fakeComplaintService.EditComplaint(id);
    //    // Assert
    //    //Assert.DoesNotThrow(Exception );
    //}

    [Test]
    public void CanReturn_MakeComplaint_ReturnsTrue_IntegrationTest()
    {
        // Arrange
        Complaint complaint = new();
        User user = new();
        user.ID = userRepository.Add(user);
        complaint.ComplainantID = user.ID;
        // Act
        complaint.ID = complaintService.MakeComplaint(complaint);
        Complaint? complaint1 = complaintService.GetComplaintByID(complaint.ID);
        // Assert
        Assert.That(complaint1, Is.EqualTo(complaint));
        // Clean 
        complaintService.RemoveComplaint(complaint.ID);
        userRepository.Delete(user);
    }

    [Test]
    public void CanReturn_MakeComplaint_ReturnsFalse_IntegrationTest()
    {
        // Arrange
        Complaint? complaint = null;
        // Act
        var returnValue = complaintService.MakeComplaint(complaint);
        // Assert
        Assert.That(returnValue, Is.EqualTo(-1));
    }

    [Test]
    public void CanReturn_RemoveComplaint_ReturnsTrue_IntegrationTest()
    {
        // Arrange
        Complaint complaint = new();
        User user = new();
        user.ID = userRepository.Add(user);
        complaint.ComplainantID = user.ID;
        complaint.ID = complaintService.MakeComplaint(complaint);
        // Act
        var returnValue = complaintService.RemoveComplaint(complaint.ID);
        // Assert
        Assert.That(returnValue, Is.EqualTo(true));
    }

    [Test]
    public void CanReturn_RemoveComplaint_ReturnsFalse_IntegrationTest()
    {
        // Arrange
        int id = -1;
        // Act
        bool returnValue = complaintService.RemoveComplaint(id);
        // Assert
        Assert.That(returnValue, Is.EqualTo(false));
    }
}
