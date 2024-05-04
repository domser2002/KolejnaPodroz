using Domain.User;
using Logic.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureTests
{
    public class UserRepositoryTest
    {
        FakeUserRepository fakeRepository;
        UserRepository repository;
        readonly string connectionString = "Server=DESKTOP-OEFV9O5,1433;Initial Catalog=Domain;Persist Security Info=False;User ID=KolejnaPodroz;Password=lubiepociagi123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"; // to be changed when moved to Azure, tests will fail on github
        [SetUp]
        public void Setup()
        {
            fakeRepository = new();
            var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
            optionsBuilder.UseSqlServer(connectionString);
            repository = new(new DomainDBContext(optionsBuilder.Options));
        }

        [Test]
        public void AddUser_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            User user = new();
            // Act 
            var result = fakeRepository.Add(user);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(user)), Is.True);
            });
        }

        [Test]
        public void DeleteUser_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            User user = new();
            fakeRepository.Add(user);
            // Act
            var result = fakeRepository.Delete(user);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(user.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateUser_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            User user = new();
            fakeRepository.Add(user);
            user.FirstName = "Test";
            // Act 
            var result = fakeRepository.Update(user);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(user.ID)?.FirstName, Is.EqualTo("Test"));
            });
        }

        [Test]
        public void AddUser_IntegrationTest()
        {
            // Arrange
            User user = new();
            int count = repository.GetAll().Count();
            // Act 
            var result = repository.Add(user);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(user)), Is.True);
            });
            // Clean
            repository.Delete(user);
        }

        [Test]
        public void DeleteUser_IntegrationTest()
        {
            // Arrange
            User user = new();
            repository.Add(user);
            // Act
            var result = repository.Delete(user);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(user.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateUser_IntegrationTest()
        {
            // Arrange
            User user = new();
            repository.Add(user);
            user.FirstName = "Test";
            // Act 
            var result = repository.Update(user);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(user.ID)?.FirstName, Is.EqualTo("Test"));
            });
            // Clean
            repository.Delete(user);
        }
    }
}
