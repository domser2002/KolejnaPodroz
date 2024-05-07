﻿using System.Collections.Generic;
using Api.Controllers;
using Domain.Common;
using Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Test;

[TestFixture]
public class ComplaintControllerTests
{
    [Test]
    public void MakeComplaint_ValidComplaint_Returns201Created()
    {
        // Arrange
        var complaintServiceMock = new Mock<IComplaintService>();
        var controller = new ComplaintController(complaintServiceMock.Object);
        var newComplaint = new Complaint { ID = 1, Content = "Test complaint" };
        complaintServiceMock.Setup(m => m.MakeComplaint(newComplaint)).Returns(true);
        // Act
        var result = controller.MakeComplaint(newComplaint);
        var createdAtActionResult = (CreatedAtActionResult?)result.Result;
        // Assert
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.RouteValues, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Result is CreatedAtActionResult, Is.True);
            Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(201));
            Assert.That(createdAtActionResult.ActionName, Is.EqualTo(nameof(controller.GetComplaintByID)));
            Assert.That(createdAtActionResult.RouteValues["id"], Is.EqualTo(newComplaint.ID));
            Assert.That(createdAtActionResult.Value, Is.EqualTo(newComplaint));
        });
        complaintServiceMock.Verify(m => m.MakeComplaint(newComplaint), Times.Once);
    }

    [Test]
    public void RemoveComplaint_ExistingID_Returns204NoContent()
    {
        // Arrange
        var complaintServiceMock = new Mock<IComplaintService>();
        complaintServiceMock.Setup(m => m.RemoveComplaint(It.IsAny<int>())).Returns(true);
        var controller = new ComplaintController(complaintServiceMock.Object);
        var id = 1;

        // Act
        var result = controller.RemoveComplaint(id);
        var createdAtActionResult = (NoContentResult?)result.Result;
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(204));
        complaintServiceMock.Verify(m => m.RemoveComplaint(id), Times.Once);
    }

    [Test]
    public void RemoveComplaint_NonExistingID_Returns404NotFound()
    {
        // Arrange
        var complaintServiceMock = new Mock<IComplaintService>();
        complaintServiceMock.Setup(m => m.RemoveComplaint(It.IsAny<int>())).Returns(false);
        var controller = new ComplaintController(complaintServiceMock.Object);
        var id = 1;

        // Act
        var result = controller.RemoveComplaint(id);
        var createdAtActionResult = (NotFoundResult?)result.Result;
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(404));
        complaintServiceMock.Verify(m => m.RemoveComplaint(id), Times.Once);
    }

    [Test]
    public void EditComplaint_ExistingID_Returns200OK()
    {
        // Arrange
        var complaintServiceMock = new Mock<IComplaintService>();
        var controller = new ComplaintController(complaintServiceMock.Object);
        var id = 1;
        Complaint newComplaint = new Complaint();

        // Act
        var result = controller.EditComplaint(id, newComplaint);
        var createdAtActionResult = (OkObjectResult?)result.Result;

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(createdAtActionResult, Is.Not.Null);
        Assert.That(createdAtActionResult.StatusCode, Is.EqualTo(200));
        Assert.That(createdAtActionResult.Value, Is.EqualTo($"Complaint {id} has been succesfully edited!"));
        complaintServiceMock.Verify(m => m.EditComplaint(id, newComplaint), Times.Once);
    }
}
