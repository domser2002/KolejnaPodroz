using Domain.Common;
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
    public class ProviderRepositoryTest
    {
        FakeProviderRepository fakeRepository;
        ProviderRepository repository;
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
        public void AddProvider_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Provider provider = new();
            int count = fakeRepository.GetAll().Count();
            // Act 
            var result = fakeRepository.Add(provider);
            // Assert
            provider.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(provider)), Is.True);
            });
        }

        [Test]
        public void DeleteProvider_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Provider provider = new();
            provider.ID = fakeRepository.Add(provider);
            // Act
            var result = fakeRepository.Delete(provider);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(provider.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateProvider_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Provider provider = new();
            provider.ID = fakeRepository.Add(provider);
            provider.Name = "aaa";
            // Act 
            var result = fakeRepository.Update(provider);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(provider.ID)?.Name, Is.EqualTo("aaa"));
            });
        }

        [Test]
        public void AddProvider_IntegrationTest()
        {
            // Arrange
            Provider provider = new();
            int count = repository.GetAll().Count();
            // Act 
            var result = repository.Add(provider);
            // Assert
            provider.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(provider)), Is.True);
            });
            // Clean
            repository.Delete(provider);
        }

        [Test]
        public void DeleteProvider_IntegrationTest()
        {
            // Arrange
            Provider provider = new();
            provider.ID = repository.Add(provider);
            // Act
            var result = repository.Delete(provider);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(provider.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateProvider_IntegrationTest()
        {
            // Arrange
            Provider provider = new();
            provider.ID = repository.Add(provider);
            provider.Name = "aaa";
            // Act 
            var result = repository.Update(provider);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(provider.ID)?.Name, Is.EqualTo("aaa"));
            });
            // Clean
            repository.Delete(provider);
        }
    }
}
