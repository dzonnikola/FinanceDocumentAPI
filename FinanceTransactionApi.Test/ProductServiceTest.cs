using FinanceTransactionApi.Models;
using FinanceTransactionApi.Repositories;
using FinanceTransactionApi.Services;
using FinanceTransactionApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace FinanceTransactionApi.Test
{
    public class ProductServiceTest
    {
        private ProductService _productService;
        private FinanceDbContext _testFinanceDbContext;
        private IProductRepository _productRepository;

        [OneTimeSetUp]
        public void Setup()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<FinanceDbContext>()
                .UseInMemoryDatabase(databaseName: "TestFinanceDb")
                .Options;

            _testFinanceDbContext = new FinanceDbContext(options);

            // Initialize repositories
            _productRepository = new ProductRepository(_testFinanceDbContext);

            // Populate database with test data
            DataStorage.PopulateProductData(_testFinanceDbContext);

            // Initialize service
            _productService = new ProductService(_productRepository);
        }

        [Test]
        public void IsProductValid_ValidProduct_ReturnsTrue()
        {
            // Act
            var result = _productService.IsProductValid("ProductA");

            // Assert
            Assert.IsTrue(result, "Valid product should return true");
        }

        [Test]
        public void IsProductValid_InvalidProduct_ReturnsFalse()
        {
            // Act
            var result = _productService.IsProductValid("ProductD");

            // Assert
            Assert.IsFalse(result, "Invalid product should return false");
        }

        [Test]
        public void IsProductValid_EmptyProductCode_ReturnsFalse()
        {
            // Act
            var result = _productService.IsProductValid("");

            // Assert
            Assert.IsFalse(result, "Empty product code should return false");
        }

        [Test]
        public void IsProductValid_NullProductCode_ReturnsFalse()
        {
            // Act
            var result = _productService.IsProductValid(null);

            // Assert
            Assert.IsFalse(result, "Null product code should return false");
        }
    }
}
