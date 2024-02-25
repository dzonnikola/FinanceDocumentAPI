using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;

namespace FinanceTransactionApi.Services
{
    public class ClientInfoService : IClientInfoService
    {
        private readonly FinanceDbContext _dbContext;

        public ClientInfoService(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public (string RegistrationNumber, CompanyType companyType) GetAditionalInfo(string clientVAT)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.ClientVAT == clientVAT);
            if (client != null)
            {
                return (client.RegistrationNumber, client.CompanyType);
            }

            return (string.Empty, CompanyType.Small);
        }

    }
}
