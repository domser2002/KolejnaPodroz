﻿using System.Collections.Generic;
using Api.Controllers;
using Domain.Common;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Test;

[TestFixture]
public class ConnectionControllerTests
{
    [Test]
    public void MakeConnection_ValidConnection_Returns201Created()
    {
        // Arrange
        var connectionServiceMock = new Mock<IConnectionService>();
        var controller = new ConnectionController(connectionServiceMock.Object);
        var newConnection = new Connection { ID = 1 };
        connectionServiceMock.Setup(m => m.AddConnection(newConnection)).Returns(1);
        // Act
        var result = controller.MakeConnection(newConnection);
        var createdAtActionResult = (OkObjectResult?)result.Result;
        // Assert
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result is OkObjectResult, Is.True);
            Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(200));
            Assert.That(createdAtActionResult.Value, Is.EqualTo(newConnection));
        });
        connectionServiceMock.Verify(m => m.AddConnection(newConnection), Times.Once);
    }

    [Test]
    public void RemoveConnection_ExistingID_Returns204NoContent()
    {
        // Arrange
        var connectionServiceMock = new Mock<IConnectionService>();
        connectionServiceMock.Setup(m => m.RemoveConnection(It.IsAny<int>())).Returns(true);
        var controller = new ConnectionController(connectionServiceMock.Object);
        var id = 1;

        // Act
        var result = controller.RemoveConnection(id);
        var createdAtActionResult = (NoContentResult?)result.Result;
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(204));
        connectionServiceMock.Verify(m => m.RemoveConnection(id), Times.Once);
    }

    [Test]
    public void RemoveConnection_NonExistingID_Returns404NotFound()
    {
        // Arrange
        var connectionServiceMock = new Mock<IConnectionService>();
        connectionServiceMock.Setup(m => m.RemoveConnection(It.IsAny<int>())).Returns(false);
        var controller = new ConnectionController(connectionServiceMock.Object);
        var id = 1;

        // Act
        var result = controller.RemoveConnection(id);
        var createdAtActionResult = (NotFoundResult?)result.Result;
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(404));
        connectionServiceMock.Verify(m => m.RemoveConnection(id), Times.Once);
    }
}
