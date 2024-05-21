using Domain.Common;
using Logic.Services.Implementations;
using Infrastructure.FakeDataRepositories;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Domain.User;

namespace Test;

public class PaymentServiceTests
{
    PaymentService paymentService;
    [SetUp]
    public void Setup()
    {
        paymentService = new();
    }
    [Test]
    public void ProceedPayment_ValidCode_ReturnsTrue()
    {
        // Arrange 
        Payment payment = new()
        {
            Code = "123456"
        };
        // Act 
        var result = paymentService.ProceedPayment(payment);
        // Assert
        Assert.That(result, Is.True);
    }
    [Test]
    public void ProceedPayment_TooShortCode_ReturnsFalse()
    {
        // Arrange 
        Payment payment = new()
        {
            Code = "1234"
        };
        // Act 
        var result = paymentService.ProceedPayment(payment);
        // Assert
        Assert.That(result, Is.False);
    }
    [Test]
    public void ProceedPayment_TooLongCode_ReturnsFalse()
    {
        // Arrange 
        Payment payment = new()
        {
            Code = "12345678"
        };
        // Act 
        var result = paymentService.ProceedPayment(payment);
        // Assert
        Assert.That(result, Is.False);
    }
    [Test]
    public void ProceedPayment_CodeWithLetters_ReturnsFalse()
    {
        // Arrange 
        Payment payment = new()
        {
            Code = "123a56"
        };
        // Act 
        var result = paymentService.ProceedPayment(payment);
        // Assert
        Assert.That(result, Is.False);
    }
    [Test]
    public void ProceedPayment_CodeNull_ReturnsFalse()
    {
        // Arrange 
        Payment payment = new()
        {
            Code = null
        };
        // Act 
        var result = paymentService.ProceedPayment(payment);
        // Assert
        Assert.That(result, Is.False);
    }
    [Test]
    public void ProceedPayment_PaymentNull_ReturnsFalse()
    {
        // Arrange 
        Payment payment = null;
        // Act 
        var result = paymentService.ProceedPayment(payment);
        // Assert
        Assert.That(result, Is.False);
    }
}
