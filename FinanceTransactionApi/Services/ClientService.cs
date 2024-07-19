using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;

namespace FinanceTransactionApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public Client GetClientDetails(Guid tenantId, Guid documentId)
        {
            return _clientRepository.GetClient(tenantId, documentId);
        }
        public bool IsClientWhiteListed(Guid tenantId, int clientId)
        {
            return _clientRepository.CheckWhiteList(tenantId, clientId);
        }
    }
}
