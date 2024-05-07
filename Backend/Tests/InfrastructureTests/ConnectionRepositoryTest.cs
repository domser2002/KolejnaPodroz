using Domain.Common;
using Logic.Services.Implementations;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTests
{
    public class ConnectionRepositoryTest
    {
        FakeConnectionRepository fakeRepository;
        ConnectionRepository repository;
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
        public void AddConnection_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Connection connection = new();
            // Act 
            var result = fakeRepository.Add(connection);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(connection)), Is.True);
            });
        }

        [Test]
        public void DeleteConnection_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Connection connection = new();
            fakeRepository.Add(connection);
            // Act
            var result = fakeRepository.Delete(connection);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(connection.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateConnection_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Connection connection = new();
            fakeRepository.Add(connection);
            connection.Stations.Add("Test");
            // Act 
            var result = fakeRepository.Update(connection);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(connection.ID)?.Stations.Last(), Is.EqualTo("Test"));
            });
        }

        [Test]
        public void AddConnection_IntegrationTest()
        {
            // Arrange
            Connection connection = new();
            int count = repository.GetAll().Count();
            // Act 
            var result = repository.Add(connection);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(connection)), Is.True);
            });
            // Clean
            repository.Delete(connection);
        }

        [Test]
        public void DeleteConnection_IntegrationTest()
        {
            // Arrange
            Connection connection = new();
            repository.Add(connection);
            // Act
            var result = repository.Delete(connection);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(connection.ID), Is.Null);
            });
        }
        // connection database is temporary approach, to uncomment once we have final implementation of repository
        //[Test]
        //public void UpdateConnection_IntegrationTest()
        //{
        //    // Arrange
        //    Connection connection = new();
        //    repository.Add(connection);
        //    connection.Stations.Add("Test");
        //    // Act 
        //    var result = repository.Update(connection);
        //    // Assert
        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(result, Is.True);
        //        Assert.That(repository.GetByID(connection.ID)?.Stations.Last(), Is.EqualTo("Test"));
        //    });
        //    // Clean
        //    repository.Delete(connection);
        //}
    }
}
