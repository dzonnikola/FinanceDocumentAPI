namespace FinanceTransactionApi.Test
{
    public class TenantServiceTest
    {
        private TenantService _tenantService;
        private FinanceDbContext _testFinanceDbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FinanceDbContext>().
                UseInMemoryDatabase(databaseName: "TestFinanceDb")
                .Options;

            _testFinanceDbContext = new FinanceDbContext(options);

            DataStorage.PopulateTenantData(_testFinanceDbContext);
            _tenantService = new TenantService(_testFinanceDbContext);

        }

        [Test]
        public void IsTenantWhitelisted_ValidTenant_ReturnsTrue()
        {
            // Act
            var result = _tenantService.IsTenantWhiteListed(Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"));

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsTenantWhitelisted_InvalidTenant_ReturnsFalse()
        {
            // Act
            var result = _tenantService.IsTenantWhiteListed(Guid.NewGuid());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsTenantWhitelisted_NullTenant_ReturnsFalse()
        {
            // Act
            var result = _tenantService.IsTenantWhiteListed(Guid.Empty);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

