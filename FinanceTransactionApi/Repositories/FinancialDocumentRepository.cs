using FinanceTransactionApi.FinanceContext;
using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTransactionApi.Repositories
{
    public class FinancialDocumentRepository : IFinancialDocumentRepository
    {
        public readonly FinanceDbContext _dbContext;
        private readonly IClientInfoService _infoService;
        private readonly IAnonymizationService _anonService;

        public FinancialDocumentRepository(FinanceDbContext dbContext, IClientInfoService infoService, IAnonymizationService anonService)
        {
            _dbContext = dbContext;
            _infoService = infoService;
            _anonService = anonService;
        }

        public FinancialDataResponse GetDocument(Guid tenantId, Guid documentId, string productCode)
        {
            var client = _dbContext.Clients
                .FirstOrDefault(c => c.TenantId == tenantId && c.DocumentId == documentId);

            if (client != null)
            {
                var financialDocumentId = client.DocumentId;

                var financialDocument = _dbContext.FinancalDocuments.Include(t => t.Transactions).FirstOrDefault(f => f.Id == financialDocumentId);

                if (financialDocument != null)
                {
                    if (financialDocument.ProductCode == productCode)
                    {
                        var companyInfo = _infoService.GetAditionalInfo(client.ClientVAT);

                        var response = new FinancialDataResponse
                        {
                            // Before returning the financial data - check if there is need for anonymization from the product config
                            Data = _dbContext.Products.FirstOrDefault(p => p.ProductCode == productCode).HashedConfiguration ?
                                    _anonService.AnonimizeData(new FinanceDocumentResponse
                                    {
                                        AccountNumber = financialDocument.AccountNumber,
                                        Balance = financialDocument.Balance,
                                        Currency = financialDocument.Currency,
                                        Transactions = financialDocument.Transactions.Where(t => t.FinnacialDocumentId == financialDocument.Id).ToList()
                                    }, productCode)
                                    :
                                    new FinanceDocumentResponse
                                    {
                                        AccountNumber = financialDocument.AccountNumber,
                                        Balance = financialDocument.Balance,
                                        Currency = financialDocument.Currency,
                                        Transactions = financialDocument.Transactions.Where(t => t.FinnacialDocumentId == financialDocument.Id).ToList()
                                    },
                            Company = new CompanyResponse
                            {
                                RegistrationNumber = companyInfo.RegistrationNumber,
                                CompanyType = companyInfo.companyType.ToString()
                            }
                        };

                        return response;
                    }
                }
                return null;

            }
            return null;

        }
    }
}
