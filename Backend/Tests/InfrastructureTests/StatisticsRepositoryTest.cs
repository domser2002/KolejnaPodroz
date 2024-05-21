using Domain.Common;
using Domain.User;
using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Infrastructure.FakeDataRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace InfrastructureTests
{
    public class StatisticsRepositoryTest
    {
        FakeStatisticsRepository fakeRepository;
        StatisticsRepository repository;
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
        public void AddStatistics_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Statistics statistics = new();
            int count = fakeRepository.GetAll().Count();
            // Act 
            var result = fakeRepository.Add(statistics);
            // Assert
            statistics.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(statistics)), Is.True);
            });
        }

        [Test]
        public void DeleteStatistics_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Statistics statistics = new();
            statistics.ID = fakeRepository.Add(statistics);
            // Act
            var result = fakeRepository.Delete(statistics);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(statistics.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateStatistics_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Statistics statistics = new();
            statistics.ID = fakeRepository.Add(statistics);
            statistics.Value = 10;
            // Act 
            var result = fakeRepository.Update(statistics);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(statistics.ID)?.Value, Is.EqualTo(10));
            });
        }

        [Test]
        public void AddStatistics_IntegrationTest()
        {
            // Arrange
            User user = new();
            Statistics statistics = new();
            int count = repository.GetAll().Count();
            user.ID = userRepository.Add(user);
            statistics.UserID = user.ID;
            statistics.CategoryID = 1;
            // Act 
            var result = repository.Add(statistics);
            // Assert
            statistics.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(statistics)), Is.True);
            });
            // Clean
            repository.Delete(statistics);
            userRepository.Delete(user);
        }

        [Test]
        public void DeleteStatistics_IntegrationTest()
        {
            // Arrange
            User user = new();
            Statistics statistics = new();
            user.ID = userRepository.Add(user);
            statistics.UserID = user.ID;
            statistics.CategoryID = 1;
            statistics.ID = repository.Add(statistics);
            // Act
            var result = repository.Delete(statistics);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(statistics.ID), Is.Null);
            });
            // Clean
            userRepository.Delete(user);
        }

        [Test]
        public void UpdateStatistics_IntegrationTest()
        {
            // Arrange
            User user = new();
            Statistics statistics = new();
            user.ID = userRepository.Add(user);
            statistics.UserID = user.ID;
            statistics.CategoryID = 1;
            statistics.ID = repository.Add(statistics);
            statistics.Value = 10;
            // Act 
            var result = repository.Update(statistics);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(statistics.ID)?.Value, Is.EqualTo(10));
            });
            // Clean
            repository.Delete(statistics);
            userRepository.Delete(user);
        }
    }
}
