using Infrastructure.DataContexts;
using Infrastructure.DataRepositories;
using Infrastructure.FakeDataRepositories;
using Logic.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTests
{
    public class StatisticsServiceTest
    {
        StatisticsService fakeStatisticsService;
        StatisticsService statisticsService;
        UserRepository userRepository;
        string? connectionString;
        [SetUp]
        public void Setup()
        {
            fakeStatisticsService = new StatisticsService(new FakeDataRepository());
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
            connectionString = configurationRoot.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            DataRepository dataRepository = new(new DomainDBContext(optionsBuilder.Options));
            userRepository = new(new DomainDBContext(optionsBuilder.Options));
            statisticsService = new StatisticsService(dataRepository);
        }
        [Test]
        public void GetByUser_UnitTest()
        {
            // Arrange
            int user_id = 1;
            // Act
            var stats = fakeStatisticsService.GetByUser(user_id);
            // Assert
            Assert.That(stats, Is.Not.Null);
            foreach(var stat in stats)
                Assert.That(stat.UserID, Is.EqualTo(user_id));
        }
        [Test]
        public void GetByCategory_UnitTest()
        {
            // Arrange
            int category_id = 1;
            // Act
            var stats = fakeStatisticsService.GetByUser(category_id);
            // Assert
            Assert.That(stats, Is.Not.Null);
            foreach (var stat in stats)
                Assert.That(stat.CategoryID, Is.EqualTo(category_id));
        }
        [Test]
        public void GetByUser_IntegrationTest()
        {
            // Arrange
            int user_id = 1;
            // Act
            var stats = statisticsService.GetByUser(user_id);
            // Assert
            Assert.That(stats, Is.Not.Null);
            foreach (var stat in stats)
                Assert.That(stat.UserID, Is.EqualTo(user_id));
        }
        [Test]
        public void GetByCategory_IntegrationTest()
        {
            // Arrange
            int category_id = 1;
            // Act
            var stats = statisticsService.GetByUser(category_id);
            // Assert
            Assert.That(stats, Is.Not.Null);
            foreach (var stat in stats)
                Assert.That(stat.CategoryID, Is.EqualTo(category_id));
        }
    }
}
