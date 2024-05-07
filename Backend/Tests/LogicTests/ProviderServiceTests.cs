//using Domain.Common;
//using Logic.Services.Implementations;

//namespace Test;

//public class ProviderServiceTests
//{

//    ProviderService providerService;
//    DatabaseService databaseService;

//    [SetUp]
//    public void Setup()
//    {
//        databaseService = new DatabaseService();
//        providerService = new ProviderService(databaseService);
//    }

//    [Test]
//    public void CanReturn_AddProvider_ReturnsFalse()
//    {
//        // Arrange
//        Provider provider = null;
//        bool canAdd;

//        // Act
//        canAdd = providerService.AddProvider(provider);

//        // Assert
//        Assert.IsFalse(canAdd);

//    }

//    [Test]
//    public void CanReturn_AddProvider_ReturnsTrue()
//    {
//        // Arrange
//        Provider provider = new Provider();
//        bool canAdd;

//        // Act
//        canAdd = providerService.AddProvider(provider);

//        // Assert
//        Assert.IsTrue(canAdd);
//    }

//    [Test]
//    public void CanReturn_RemoveProvider_ReturnsTrue()
//    {
//        // Arrange
//        Provider provider = new Provider();
//        bool canAdd, canRemove;

//        // Act
//        canAdd = providerService.AddProvider(provider);
//        canRemove = providerService.RemoveProvider(provider.ID);

//        // Assert
//        Assert.IsTrue(canRemove);
//    }

//    [Test]
//    public void CanReturn_RemoveProvider_ReturnsFalse()
//    {
//        // Arrange
//        bool canRemove;

//        // Act
//        canRemove = providerService.RemoveProvider(-1);

//        // Assert
//        Assert.IsFalse(canRemove);
//    }

//    [Test]
//    public void CanReturn_GetProvider_ReturnsTrue()
//    {
//        // Arrange
//        Provider provider = new Provider();
//        Provider provider2 = null;

//        // Act
//        provider2 = databaseService.GetProvider(provider.ID);

//        // Assert
//        Assert.AreEqual(provider.ID, provider2.ID);
//    }
//}
