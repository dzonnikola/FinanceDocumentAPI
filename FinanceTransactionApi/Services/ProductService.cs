using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;
using System;

namespace FinanceTransactionApi.Services
{
    public class ProductService : IProductService
    {
        private readonly FinanceDbContext _dbContext;
        public ProductService(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsProductValid(string productCode)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductCode == productCode);

            if (product == null)
            {
                return false;
            }

            return product.IsSupported;
        }
    }
}
