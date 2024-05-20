using Domain.Admin;
using Logic.Services.Implementations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTests
{
    public class AdminRepositoryTest
    {
        FakeAdminRepository fakeRepository;
        AdminRepository repository;
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
            repository = new(new DomainDBContext(optionsBuilder.Options));
        }

        [Test]
        public void AddAdmin_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Admin admin = new();
            int count = fakeRepository.GetAll().Count();
            // Act 
            var result = fakeRepository.Add(admin);
            // Assert
            admin.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(admin)), Is.True);
            });
        }

        [Test]
        public void DeleteAdmin_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Admin admin = new();
            admin.ID = fakeRepository.Add(admin);
            // Act
            var result = fakeRepository.Delete(admin);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(admin.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateAdmin_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Admin admin = new();
            admin.ID = fakeRepository.Add(admin);
            admin.Accepted = !admin.Accepted;
            // Act 
            var result = fakeRepository.Update(admin);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(admin.ID)?.Accepted, Is.True);
            });
        }

        [Test]
        public void AddAdmin_IntegrationTest()
        {
            // Arrange
            Admin admin = new();
            int count = repository.GetAll().Count();
            // Act 
            var result = repository.Add(admin);
            // Assert
            admin.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(admin)), Is.True);
            });
            // Clean
            repository.Delete(admin);
        }

        [Test]
        public void DeleteAdmin_IntegrationTest()
        {
            // Arrange
            Admin admin = new();
            admin.ID = repository.Add(admin);
            // Act
            var result = repository.Delete(admin);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(admin.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateAdmin_IntegrationTest()
        {
            // Arrange
            Admin admin = new();
            admin.ID = repository.Add(admin);
            admin.Accepted = !admin.Accepted;
            // Act 
            var result = repository.Update(admin);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(admin.ID)?.Accepted, Is.True);
            });
            // Clean
            repository.Delete(admin);
        }
    }
}
