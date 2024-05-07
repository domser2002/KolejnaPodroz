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
    public class TicketRepositoryTest
    {
        FakeTicketRepository fakeRepository;
        TicketRepository repository;
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
        public void AddTicket_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Ticket ticket = new();
            int count = fakeRepository.GetAll().Count();
            // Act 
            var result = fakeRepository.Add(ticket);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(fakeRepository.GetAll().Any(u => u.Equals(ticket)), Is.True);
            });
        }

        [Test]
        public void DeleteTicket_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Ticket ticket = new();
            fakeRepository.Add(ticket);
            // Act
            var result = fakeRepository.Delete(ticket);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(ticket.ID), Is.Null);
            });
        }

        [Test]
        public void UpdateTicket_UnitTest()
        {
            // Arrange
            fakeRepository = new();
            Ticket ticket = new();
            fakeRepository.Add(ticket);
            ticket.ConnectionID = 10;
            // Act 
            var result = fakeRepository.Update(ticket);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(fakeRepository.GetByID(ticket.ID)?.ConnectionID, Is.EqualTo(10));
            });
        }

        [Test]
        public void AddTicket_IntegrationTest()
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
            Ticket ticket = new()
            {
                ID = test_id
            };
            int count = repository.GetAll().Count();
            userRepository.Add(user);
            ticket.OwnerID = user.ID;
            // Act 
            var result = repository.Add(ticket);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetAll().Count(), Is.EqualTo(count + 1));
                Assert.That(repository.GetAll().Any(u => u.Equals(ticket)), Is.True);
            });
            // Clean
            repository.Delete(ticket);
            userRepository.Delete(user);
        }

        [Test]
        public void DeleteTicket_IntegrationTest()
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
            Ticket ticket = new()
            {
                ID = test_id
            };
            userRepository.Add(user);
            ticket.OwnerID = user.ID;
            repository.Add(ticket);
            // Act
            var result = repository.Delete(ticket);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(ticket.ID), Is.Null);
            });
            // Clean
            userRepository.Delete(user);
        }

        [Test]
        public void UpdateTicket_IntegrationTest()
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
            Ticket ticket = new()
            {
                ID = test_id
            };
            userRepository.Add(user);
            ticket.OwnerID = user.ID;
            repository.Add(ticket);
            ticket.ConnectionID = 10;
            // Act 
            var result = repository.Update(ticket);
            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.True);
                Assert.That(repository.GetByID(ticket.ID)?.ConnectionID, Is.EqualTo(10));
            });
            // Clean
            repository.Delete(ticket);
            userRepository.Delete(user);
        }
    }
}
