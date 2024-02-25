using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    /// <summary>
    /// IProductService interface
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Determines whether [is product valid] [the specified product code].
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns>
        ///   <c>true</c> if [is product valid] [the specified product code]; otherwise, <c>false</c>.
        /// </returns>
        bool IsProductValid(string productCode);
    }
}
