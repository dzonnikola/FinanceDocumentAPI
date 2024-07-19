using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    public interface IClientRepository
    {
        Client GetClient(Guid tenantId, Guid documentId);
        bool CheckWhiteList(Guid tenantId, int clientId);
        Client GetClient(string clientVAT);

    }
}
