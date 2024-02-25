using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    /// <summary>
    /// IAnonymizationService interface
    /// </summary>
    public interface IAnonymizationService
    {
        /// <summary>
        /// Anonimizes the data.
        /// </summary>
        /// <param name="financialData">The financial data.</param>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        FinanceDocumentResponse AnonimizeData(FinanceDocumentResponse financialData, string productCode);
    }
}
