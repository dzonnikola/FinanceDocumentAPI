using FinanceTransactionApi.Models;
using FinanceTransactionApi.Repositories;
using FinanceTransactionApi.Services;
using FinanceTransactionApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FinanceTransactionApi.Test
{
    public class TenantServiceTest
    {
        private TenantService _tenantService;
        private FinanceDbContext _testFinanceDbContext;
        private ITenantRepository _tenantRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<FinanceDbContext>()
                .UseInMemoryDatabase(databaseName: "TestFinanceDb")
                .Options;

            _testFinanceDbContext = new FinanceDbContext(options);

            // Initialize repositories
            _tenantRepository = new TenantRepository(_testFinanceDbContext);

            // Populate database with test data
            DataStorage.PopulateTenantData(_testFinanceDbContext);

            // Initialize service
            _tenantService = new TenantService(_tenantRepository);
        }

        [Test]
        public void IsTenantWhitelisted_ValidTenant_ReturnsTrue()
        {
            // Act
            var result = _tenantService.IsTenantWhiteListed(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"));

            // Assert
            Assert.IsTrue(result, "Valid tenant should return true");
        }

        [Test]
        public void IsTenantWhitelisted_InvalidTenant_ReturnsFalse()
        {
            // Act
            var result = _tenantService.IsTenantWhiteListed(Guid.NewGuid());

            // Assert
            Assert.IsFalse(result, "Invalid tenant should return false");
        }

        [Test]
        public void IsTenantWhitelisted_NullTenant_ReturnsFalse()
        {
            // Act
            var result = _tenantService.IsTenantWhiteListed(Guid.Empty);

            // Assert
            Assert.IsFalse(result, "Empty tenant GUID should return false");
        }
    }
}
