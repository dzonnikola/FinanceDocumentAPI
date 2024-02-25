using FinanceTransactionApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceTransactionApi.Test
{
    public class ClientServiceTests
    {
        private ClientService _clientService;
        private FinanceDbContext _testFinanceDbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FinanceDbContext>().
                UseInMemoryDatabase(databaseName: "TestFinanceDb")
                .Options;

            _testFinanceDbContext = new FinanceDbContext(options);

            DataStorage.PopulateClientData(_testFinanceDbContext);

            _clientService = new ClientService(_testFinanceDbContext);
        }


        [Test]
        public void IsClientWhitelisted_ValidClient_ReturnsTrue()
        {
            // Act
            var result = _clientService.IsClientWhiteListed(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"), 1);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void GetClientInfo_ValidInput_ReturnsClient()
        {
            // Act
            var result = _clientService.GetClientDetails(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"),Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126"));

            // Assert
            Assert.NotNull(result);
            Assert.That(result.TenantId, Is.EqualTo(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed")));
            Assert.That(result.DocumentId, Is.EqualTo(Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126")));
        }

        [Test]
        public void GetClientInfo_InvalidInput_ReturnsNull()
        {
            // Act
            var result = _clientService.GetClientDetails(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"), Guid.Parse("8d3cb2b0-0eb8-4a72-aaed-224ebd8ae123"));

            // Assert
            Assert.Null(result);
        }
    }
}
