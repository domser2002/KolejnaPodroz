using Domain.Common;
using Logic.Services.Implementations;
using Infrastructure.FakeDataRepositories;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.User;

namespace Test;

public class ProviderServiceTests
{
    ProviderService fakeProviderService;
    ProviderService providerService;
    string? connectionString;
    [SetUp]
    public void Setup()
    {
        fakeProviderService = new ProviderService(new FakeDataRepository(), null);
        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
.SetBasePath(Directory.GetCurrentDirectory())
.AddJsonFile("appsettings.json")
.Build();
        connectionString = configurationRoot.GetConnectionString("DefaultConnection");
        var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
        optionsBuilder.UseSqlServer(connectionString);
        DataRepository dataRepository = new(new DomainDBContext(optionsBuilder.Options));
        providerService = new ProviderService(dataRepository, null);
    }

    [Test]
    public void CanReturn_MakeProvider_ReturnsTrue_UnitTest()
    {
        // Arrange
        Provider provider = new();
        // Act
        provider.ID = fakeProviderService.AddProvider(provider);
        Provider? provider1 = fakeProviderService.GetProviderByID(provider.ID);
        // Assert
        Assert.That(provider1, Is.EqualTo(provider));
    }

    [Test]
    public void CanReturn_MakeProvider_ReturnsFalse_UnitTest()
    {
        // Arrange
        Provider? provider = null;
        // Act
        var returnValue = fakeProviderService.AddProvider(provider);
        // Assert
        Assert.That(returnValue, Is.EqualTo(-1));
    }

    [Test]
    public void CanReturn_RemoveProvider_ReturnsTrue_UnitTest()
    {
        // Arrange
        Provider provider = new();
        provider.ID = fakeProviderService.AddProvider(provider);
        // Act
        bool returnValue = fakeProviderService.RemoveProvider(provider.ID);
        // Assert
        Assert.That(returnValue, Is.EqualTo(true));
    }

    [Test]
    public void CanReturn_RemoveProvider_ReturnsFalse_UnitTest()
    {
        // Arrange
        int id = -1;
        // Act
        bool returnValue = fakeProviderService.RemoveProvider(id);
        // Assert
        Assert.That(returnValue, Is.EqualTo(false));
    }

    // edit provider must be refactored
    //[Test]
    //public void CanExecute_EditProvider_ReturnsTrue()
    //{
    //    // Arrange
    //    int id = 1;
    //    // Act
    //    fakeProviderService.EditProvider(id);
    //    // Assert
    //    //Assert.DoesNotThrow(Exception );
    //}

    [Test]
    public void CanReturn_MakeProvider_ReturnsTrue_IntegrationTest()
    {
        // Arrange
        Provider provider = new();
        // Act
        provider.ID = providerService.AddProvider(provider);
        Provider? provider1 = providerService.GetProviderByID(provider.ID);
        // Assert
        Assert.That(provider1, Is.EqualTo(provider));
        // Clean 
        providerService.RemoveProvider(provider.ID);
    }

    [Test]
    public void CanReturn_MakeProvider_ReturnsFalse_IntegrationTest()
    {
        // Arrange
        Provider? provider = null;
        // Act
        var returnValue = providerService.AddProvider(provider);
        // Assert
        Assert.That(returnValue, Is.EqualTo(-1));
    }

    [Test]
    public void CanReturn_RemoveProvider_ReturnsTrue_IntegrationTest()
    {
        // Arrange
        Provider provider = new();
        provider.ID = providerService.AddProvider(provider);
        // Act
        bool returnValue = providerService.RemoveProvider(provider.ID);
        // Assert
        Assert.That(returnValue, Is.EqualTo(true));
    }

    [Test]
    public void CanReturn_RemoveProvider_ReturnsFalse_IntegrationTest()
    {
        // Arrange
        int id = -1;
        // Act
        bool returnValue = providerService.RemoveProvider(id);
        // Assert
        Assert.That(returnValue, Is.EqualTo(false));
    }
}
