using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;

namespace FinanceTransactionApi.Services
{
    public class ClientService : IClientService
    {
        private readonly FinanceDbContext _dbContext;

        public ClientService(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Client GetClientDetails(Guid tenantId, Guid documentId)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.TenantId == tenantId && c.DocumentId == documentId);
        }
        public bool IsClientWhiteListed(Guid tenantId, int clientId)
        {
            return _dbContext.Clients.Any(c => c.TenantId == tenantId && c.ClientId == clientId && c.IsWhiteListed);
        }
    }
}
