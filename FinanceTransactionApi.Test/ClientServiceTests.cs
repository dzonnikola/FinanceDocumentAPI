using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace FinanceTransactionApi.Test
{
    public class ClientServiceTests
    {
        private ClientService _clientService;
        private FinanceDbContext _testFinanceDbContext;
        private IClientRepository _clientRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<FinanceDbContext>()
                .UseInMemoryDatabase(databaseName: "TestFinanceDb")
                .Options;

            _testFinanceDbContext = new FinanceDbContext(options);

            // Initialize repositories
            _clientRepository = new ClientRepository(_testFinanceDbContext);

            // Populate database with test data
            DataStorage.PopulateClientData(_testFinanceDbContext);

            // Initialize service
            _clientService = new ClientService(_clientRepository);
        }

        [Test]
        public void IsClientWhitelisted_ValidClient_ReturnsTrue()
        {
            // Act
            var result = _clientService.IsClientWhiteListed(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"), 1);

            // Assert
            Assert.True(result, "Client should be whitelisted");
        }

        [Test]
        public void GetClientInfo_ValidInput_ReturnsClient()
        {
            // Act
            var result = _clientService.GetClientDetails(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"), Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126"));

            // Assert
            Assert.NotNull(result, "Client details should not be null");
            Assert.That(result.TenantId, Is.EqualTo(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed")), "TenantId does not match");
            Assert.That(result.DocumentId, Is.EqualTo(Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126")), "DocumentId does not match");
        }

        [Test]
        public void GetClientInfo_InvalidInput_ReturnsNull()
        {
            // Act
            var result = _clientService.GetClientDetails(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"), Guid.Parse("8d3cb2b0-0eb8-4a72-aaed-224ebd8ae123"));

            // Assert
            Assert.Null(result, "Client details should be null for invalid input");
        }
    }
}
