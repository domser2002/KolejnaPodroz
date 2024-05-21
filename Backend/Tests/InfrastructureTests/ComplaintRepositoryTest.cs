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
            complaint.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
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
            complaint.ID = fakeRepository.Add(complaint);
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
            Complaint oldComplaint = new();
            oldComplaint.ID = fakeRepository.Add(oldComplaint);
            Complaint newComplaint = new()
            {
                ID = oldComplaint.ID,
                Content = "Test"
            };
            // Act 
            var result = fakeRepository.Update(oldComplaint,newComplaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(oldComplaint.ID)?.Content, Is.EqualTo("Test"));
            });
        }

        [Test]
        public void AddComplaint_IntegrationTest()
        {
            // Arrange
            User user = new();
            Complaint complaint = new();
            int count = repository.GetAll().Count();
            int id = userRepository.Add(user);
            user.ID = id;
            complaint.ComplainantID = id;
            // Act 
            var result = repository.Add(complaint);
            // Assert
            complaint.ID = result;
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.EqualTo(-1));
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
            User user = new();
            Complaint complaint = new();
            user.ID = userRepository.Add(user);
            complaint.ComplainantID = user.ID;
            complaint.ID = repository.Add(complaint);
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
            User user = new();
            Complaint oldComplaint = new();
            user.ID = userRepository.Add(user);
            oldComplaint.ComplainantID = user.ID;
            oldComplaint.ID = repository.Add(oldComplaint);
            Complaint newComplaint = new()
            {
                ID = oldComplaint.ID,
                ComplainantID = oldComplaint.ComplainantID,
                Content = "Test"
            };
            // Act 
            var result = repository.Update(oldComplaint,newComplaint);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(oldComplaint.ID)?.Content, Is.EqualTo("Test"));
            });
            // Clean
            repository.Delete(newComplaint);
            userRepository.Delete(user);
        }
    }
}
