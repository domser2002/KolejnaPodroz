using Domain.User;
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
        }

        [Test]
        public void AddDiscount_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Discount discount = new();
            int count = fakeRepository.GetAll().Count();
            // Act 
            var result = fakeRepository.Add(discount);
            // Assert
            discount.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(discount)), Is.True);
            });
        }

        [Test]
        public void DeleteDiscount_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Discount discount = new();
            discount.ID = fakeRepository.Add(discount);
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
            discount.ID = fakeRepository.Add(discount);
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

        [Test]
        public void AddDiscount_IntegrationTest()
        {
            // Arrange
            Discount discount = new();
            int count = repository.GetAll().Count();
            // Act 
            var result = repository.Add(discount);
            // Assert
            discount.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(discount)), Is.True);
            });
            // Clean
            repository.Delete(discount);
        }

        [Test]
        public void DeleteDiscount_IntegrationTest()
        {
            // Arrange
            Discount discount = new();
            discount.ID = repository.Add(discount);
            // Act
            var result = repository.Delete(discount);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(discount.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateDiscount_IntegrationTest()
        {
            // Arrange
            Discount discount = new();
            discount.ID = repository.Add(discount);
            discount.Percentage = 10;
            // Act 
            var result = repository.Update(discount);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(discount.ID)?.Percentage, Is.EqualTo(10));
            });
            // Clean
            repository.Delete(discount);
        }
    }
}
