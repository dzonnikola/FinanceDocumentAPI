using FinanceTransactionApi.FinanceContext;
using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;

namespace FinanceTransactionApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FinanceDbContext _dbContext;
        public ProductRepository(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product GetProductByCode(string productCode)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductCode == productCode);
        }
    }
}
