using Domain.Common;
using Logic.Services.Implementations;
using Infrastructure.FakeDataRepositories;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.User;

namespace Test;

public class ConnectionServiceTests
{
    ConnectionService fakeConnectionService;
    ConnectionService connectionService;
    string? connectionString;
    [SetUp]
    public void Setup()
    {
        fakeConnectionService = new ConnectionService(new FakeDataRepository());
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.Build();
        connectionString = configurationRoot.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
        optionsBuilder.UseSqlServer(connectionString);
        DataRepository dataRepository = new(new DomainDBContext(optionsBuilder.Options));
        connectionService = new ConnectionService(dataRepository);
    }

    [Test]
    public void CanReturn_MakeConnection_ReturnsTrue_UnitTest()
    {
        // Arrange
        Connection connection = new();
        // Act
        connection.ID = fakeConnectionService.AddConnection(connection);
        Connection? connection1 = fakeConnectionService.GetConnectionByID(connection.ID);
        // Assert
        Assert.That(connection1, Is.EqualTo(connection));
    }

    [Test]
    public void CanReturn_MakeConnection_ReturnsFalse_UnitTest()
    {
        // Arrange
        Connection? connection = null;
        // Act
        var returnValue = fakeConnectionService.AddConnection(connection);
        // Assert
        Assert.That(returnValue, Is.EqualTo(-1));
    }

    [Test]
    public void CanReturn_RemoveConnection_ReturnsTrue_UnitTest()
    {
        // Arrange
        Connection connection = new();
        connection.ID = fakeConnectionService.AddConnection(connection);
        // Act
        bool returnValue = fakeConnectionService.RemoveConnection(connection.ID);
        // Assert
        Assert.That(returnValue, Is.EqualTo(true));
    }

    [Test]
    public void CanReturn_RemoveConnection_ReturnsFalse_UnitTest()
    {
        // Arrange
        int id = -1;
        // Act
        bool returnValue = fakeConnectionService.RemoveConnection(id);
        // Assert
        Assert.That(returnValue, Is.EqualTo(false));
    }

    // edit connection must be refactored
    //[Test]
    //public void CanExecute_EditConnection_ReturnsTrue()
    //{
    //    // Arrange
    //    int id = 1;
    //    // Act
    //    fakeConnectionService.EditConnection(id);
    //    // Assert
    //    //Assert.DoesNotThrow(Exception );
    //}

    [Test]
    public void CanReturn_MakeConnection_ReturnsTrue_IntegrationTest()
    {
        // Arrange
        Connection connection = new();
        // Act
        connection.ID = connectionService.AddConnection(connection);
        Connection? connection1 = connectionService.GetConnectionByID(connection.ID);
        // Assert
        Assert.That(connection1, Is.EqualTo(connection));
        // Clean 
        connectionService.RemoveConnection(connection.ID);
    }

    [Test]
    public void CanReturn_MakeConnection_ReturnsFalse_IntegrationTest()
    {
        // Arrange
        Connection? connection = null;
        // Act
        var returnValue = connectionService.AddConnection(connection);
        // Assert
        Assert.That(returnValue, Is.EqualTo(-1));
    }

    [Test]
    public void CanReturn_RemoveConnection_ReturnsTrue_IntegrationTest()
    {
        // Arrange
        Connection connection = new();
        connection.ID = connectionService.AddConnection(connection);
        // Act
        bool returnValue = connectionService.RemoveConnection(connection.ID);
        // Assert
        Assert.That(returnValue, Is.EqualTo(true));
    }

    [Test]
    public void CanReturn_RemoveConnection_ReturnsFalse_IntegrationTest()
    {
        // Arrange
        int id = -1;
        // Act
        bool returnValue = connectionService.RemoveConnection(id);
        // Assert
        Assert.That(returnValue, Is.EqualTo(false));
    }
}
