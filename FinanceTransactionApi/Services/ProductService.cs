using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;
using System;

namespace FinanceTransactionApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public bool IsProductValid(string productCode)
        {
            var product = _productRepository.GetProductByCode(productCode);
            return product != null && product.IsSupported;
        }
    }
}
