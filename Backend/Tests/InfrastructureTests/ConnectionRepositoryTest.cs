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
        ProviderRepository providerRepository;
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
            providerRepository = new(new DomainDBContext(optionsBuilder.Options));
        }

        [Test]
        public void AddConnection_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Connection connection = new();
            int count = fakeRepository.GetAll().Count();
            // Act 
            var result = fakeRepository.Add(connection);
            // Assert
            connection.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(connection)), Is.True);
            });
        }

        [Test]
        public void DeleteConnection_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Connection connection = new();
            connection.ID = fakeRepository.Add(connection);
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
        public void AddConnection_IntegrationTest()
        {
            // Arrange
            Connection connection = new();
            Provider provider = new();
            int providerID = providerRepository.Add(provider);
            connection.ProviderID = providerID;
            int count = repository.GetAll().Count();
            // Act 
            var result = repository.Add(connection);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(connection)), Is.True);
            });
            // Clean
            repository.Delete(connection);
            providerRepository.Delete(provider);
        }

        [Test]
        public void DeleteConnection_IntegrationTest()
        {
            // Arrange
            Connection connection = new();
            Provider provider = new();
            int providerID = providerRepository.Add(provider);
            connection.ProviderID = providerID;
            repository.Add(connection);
            // Act
            var result = repository.Delete(connection);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(connection.ID), Is.Null);
            });
            // Clean
            providerRepository.Delete(provider);
        }
    }
}
