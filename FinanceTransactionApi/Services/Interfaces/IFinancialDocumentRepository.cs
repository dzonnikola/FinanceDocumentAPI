using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    public interface IFinancialDocumentRepository
    {
        FinancialDataResponse GetDocument(Guid tenantId, Guid documentId, string productCode);
    }
}
