using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;

namespace FinanceTransactionApi.Services
{
    public class CompanyTypeService : ICompanyTypeCheck
    {
        public bool IsCompanySmall(CompanyType companyType)
        {
            return companyType == CompanyType.Small;
        }
    }
}
