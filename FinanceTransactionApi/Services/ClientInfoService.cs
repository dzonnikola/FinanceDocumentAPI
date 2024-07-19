using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;

namespace FinanceTransactionApi.Services
{
    public class ClientInfoService : IClientInfoService
    {
        
        private readonly IClientRepository _clientRepository;

        public ClientInfoService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public (string RegistrationNumber, CompanyType companyType) GetAditionalInfo(string clientVAT)
        {
            var client = _clientRepository.GetClient(clientVAT);
            if (client != null)
            {
                return (client.RegistrationNumber, client.CompanyType);
            }

            return (string.Empty, CompanyType.Small);
        }

    }
}
