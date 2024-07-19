using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;
using Microsoft.EntityFrameworkCore;

namespace FinanceTransactionApi.Services
{
    public class FinancialDocumentService : IFinancialDocumentService
    {
        private readonly IFinancialDocumentRepository _financialDocumentRepository;

        public FinancialDocumentService(IFinancialDocumentRepository financialDocumentRepository)
        {
            _financialDocumentRepository = financialDocumentRepository;
        }
        public FinancialDataResponse GetFinancialDocument(Guid tenantId, Guid documentId, string productCode)
        {
            return _financialDocumentRepository.GetDocument(tenantId, documentId, productCode);
        }
    }
}
