using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    /// <summary>
    /// IFinancialDocumentService interface
    /// </summary>
    public interface IFinancialDocumentService
    {
        /// <summary>
        /// Gets the financial document.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        FinancialDataResponse GetFinancialDocument(Guid tenantId, Guid documentId, string productCode);
    }
}
