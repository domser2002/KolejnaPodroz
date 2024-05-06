﻿using Domain.User;
using Infrastructure.Interfaces;
using Logic.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTests
{
    public class DiscountRepositoryTest
    {
        FakeDiscountRepository fakeRepository;
        DiscountRepository repository;
        UserRepository userRepository; // needed because of relation
        string? connectionString;
        [SetUp]
        public void Setup()
        {
            fakeRepository = new();
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
            connectionString = configurationRoot.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            DomainDBContext dataContext = new(optionsBuilder.Options);
            repository = new(dataContext);
            userRepository = new(dataContext);
        }

        [Test]
        public void AddDiscount_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Discount discount = new();
            // Act 
            var result = fakeRepository.Add(discount);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(discount)), Is.True);
            });
        }

        [Test]
        public void DeleteDiscount_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Discount discount = new();
            fakeRepository.Add(discount);
            // Act
            var result = fakeRepository.Delete(discount);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(discount.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateDiscount_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Discount discount = new();
            fakeRepository.Add(discount);
            discount.Percentage = 10;
            // Act 
            var result = fakeRepository.Update(discount);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(discount.ID)?.Percentage, Is.EqualTo(10));
            });
        }

        //[Test]
        //public void AddDiscount_IntegrationTest()
        //{
        //    // Arrange
        //    User user = new();
        //    Discount discount = new();
        //    int count = repository.GetAll().Count();
        //    userRepository.Add(user);
        //    discount.OwnerID = user.ID;
        //    // Act 
        //    var result = repository.Add(discount);
        //    // Assert
        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(result, Is.True);
        //        Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
        //        Assert.That(repository.GetAll().Any(u => u.Equals(discount)), Is.True);
        //    });
        //    // Clean
        //    repository.Delete(discount);
        //    userRepository.Delete(user);
        //}

        //[Test]
        //public void DeleteDiscount_IntegrationTest()
        //{
        //    // Arrange
        //    User user = new();
        //    Discount discount = new();
        //    userRepository.Add(user);
        //    discount.OwnerID = user.ID;
        //    repository.Add(discount);
        //    // Act
        //    var result = repository.Delete(discount);
        //    // Assert
        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(result, Is.True);
        //        Assert.That(repository.GetByID(discount.ID), Is.Null);
        //    });
        //    // Clean
        //    userRepository.Delete(user);
        //}

        //[Test]
        //public void UpdateDiscount_IntegrationTest()
        //{
        //    // Arrange
        //    User user = new();
        //    Discount discount = new();
        //    userRepository.Add(user);
        //    discount.OwnerID = user.ID;
        //    repository.Add(discount);
        //    discount.ConnectionID = 10;
        //    // Act 
        //    var result = repository.Update(discount);
        //    // Assert
        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(result, Is.True);
        //        Assert.That(repository.GetByID(discount.ID)?.ConnectionID, Is.EqualTo(10));
        //    });
        //    // Clean
        //    repository.Delete(discount);
        //    userRepository.Delete(user);
        //}
    }
}
