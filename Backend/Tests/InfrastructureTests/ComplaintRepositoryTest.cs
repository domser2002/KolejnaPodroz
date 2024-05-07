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
    public class ComplaintRepositoryTest
    {
        FakeComplaintRepository fakeRepository;
        ComplaintRepository repository;
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
        public void AddComplaint_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Complaint complaint = new();
            int count = fakeRepository.GetAll().Count();
            // Act 
            var result = fakeRepository.Add(complaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(complaint)), Is.True);
            });
        }

        [Test]
        public void DeleteComplaint_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Complaint complaint = new();
            fakeRepository.Add(complaint);
            // Act
            var result = fakeRepository.Delete(complaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(complaint.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateComplaint_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Complaint complaint = new();
            fakeRepository.Add(complaint);
            complaint.Content = "Test";
            // Act 
            var result = fakeRepository.Update(complaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(complaint.ID)?.Content, Is.EqualTo("Test"));
            });
        }

        [Test]
        public void AddComplaint_IntegrationTest()
        {
            // Arrange
            int test_id = 99999;
            User? u = userRepository.GetByID(test_id);
            if(u != null)
            {
                userRepository.Delete(u);
            }
            User user = new()
            {
                ID = test_id
            };
            Complaint complaint = new()
            {
                ID = test_id
            };
            int count = repository.GetAll().Count();
            userRepository.Add(user);
            complaint.ComplainantID = user.ID;
            // Act 
            var result = repository.Add(complaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(complaint)), Is.True);
            });
            // Clean
            repository.Delete(complaint);
            userRepository.Delete(user);
        }

        [Test]
        public void DeleteComplaint_IntegrationTest()
        {
            // Arrange
            int test_id = 99999;
            User? u = userRepository.GetByID(test_id);
            if (u != null)
            {
                userRepository.Delete(u);
            }
            User user = new()
            {
                ID = test_id
            };
            Complaint complaint = new()
            {
                ID = test_id
            };
            userRepository.Add(user);
            complaint.ComplainantID = user.ID;
            repository.Add(complaint);
            // Act
            var result = repository.Delete(complaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(complaint.ID), Is.Null);
            });
            // Clean
            userRepository.Delete(user);
        }

        [Test]
        public void UpdateComplaint_IntegrationTest()
        {
            // Arrange
            int test_id = 99999;
            User? u = userRepository.GetByID(test_id);
            if (u != null)
            {
                userRepository.Delete(u);
            }
            User user = new()
            {
                ID = test_id
            };
            Complaint complaint = new()
            {
                ID = test_id
            };
            userRepository.Add(user);
            complaint.ComplainantID = user.ID;
            repository.Add(complaint);
            complaint.Content = "Test";
            // Act 
            var result = repository.Update(complaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(complaint.ID)?.Content, Is.EqualTo("Test"));
            });
            // Clean
            repository.Delete(complaint);
            userRepository.Delete(user);
        }
    }
}
