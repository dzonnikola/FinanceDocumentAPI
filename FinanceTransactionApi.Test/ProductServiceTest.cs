using Microsoft.EntityFrameworkCore;

namespace FinanceTransactionApi.Test
{
    public class ProductServiceTest
    {
        private ProductService _productService;
        private FinanceDbContext _testFinanceDbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<FinanceDbContext>().
                UseInMemoryDatabase(databaseName: "TestFinanceDb")
                .Options;

            _testFinanceDbContext = new FinanceDbContext(options);

            DataStorage.PopulateProductData(_testFinanceDbContext);
            _productService = new ProductService(_testFinanceDbContext);

        }

        [Test]
        public void IsProductValid_ValidProduct_ReturnsTrue()
        {
            //Act
            var result = _productService.IsProductValid("ProductA");

            //Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void IsProductValid_InvalidProduct_ReturnsFalse()
        {
            // Act
            var result = _productService.IsProductValid("ProductD");

            //Assert
            Assert.IsFalse(result);

        }

        [Test]
        public void IsProductValid_EmptyProductCode_ReturnsFalse()
        {
            // Act
            var result = _productService.IsProductValid("");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsProductValid_NullProductCode_ReturnsFalse()
        {
            // Act
            var result = _productService.IsProductValid(null);

            // Assert
            Assert.IsFalse(result);
        }
    }


}
