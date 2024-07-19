using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    public interface IProductRepository
    {
        Product GetProductByCode(string productCode);
    }
}
