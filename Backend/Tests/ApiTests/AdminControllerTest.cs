using System.Collections.Generic;
using Api.Controllers;
using Domain.Admin;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Test;

[TestFixture]
public class AdminControllerTests
{
    [Test]
    public void MakeAdmin_ValidAdmin_Returns201Created()
    {
        // Arrange
        var adminServiceMock = new Mock<IAdminService>();
        var controller = new AdminController(adminServiceMock.Object);
        var newAdmin = new Admin { ID = 1 };
        adminServiceMock.Setup(m => m.CreateAdminAccount(newAdmin)).Returns(true);
        // Act
        var result = controller.CreateAccount(newAdmin);
        var createdAtActionResult = (CreatedAtActionResult?)result.Result;
        // Assert
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.RouteValues, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result is CreatedAtActionResult, Is.True);
            Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(201));
            Assert.That(createdAtActionResult.RouteValues["id"], Is.EqualTo(newAdmin.ID));
            Assert.That(createdAtActionResult.Value, Is.EqualTo(newAdmin));
        });
        adminServiceMock.Verify(m => m.CreateAdminAccount(newAdmin), Times.Once);
    }

    [Test]
    public void DeleteAccount_ExistingID_Returns204NoContent()
    {
        // Arrange
        var adminServiceMock = new Mock<IAdminService>();
        adminServiceMock.Setup(m => m.RemoveAdminAccount(It.IsAny<int>())).Returns(true);
        var controller = new AdminController(adminServiceMock.Object);
        var id = 1;

        // Act
        var result = controller.DeleteAccount(id);
        var createdAtActionResult = (NoContentResult?)result.Result;
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(204));
        adminServiceMock.Verify(m => m.RemoveAdminAccount(id), Times.Once);
    }

    [Test]
    public void DeleteAccount_NonExistingID_Returns404NotFound()
    {
        // Arrange
        var adminServiceMock = new Mock<IAdminService>();
        adminServiceMock.Setup(m => m.RemoveAdminAccount(It.IsAny<int>())).Returns(false);
        var controller = new AdminController(adminServiceMock.Object);
        var id = 1;

        // Act
        var result = controller.DeleteAccount(id);
        var createdAtActionResult = (NotFoundResult?)result.Result;
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(404));
        adminServiceMock.Verify(m => m.RemoveAdminAccount(id), Times.Once);
    }
}
