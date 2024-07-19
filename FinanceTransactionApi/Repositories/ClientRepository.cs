using FinanceTransactionApi.FinanceContext;
using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceTransactionApi.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly FinanceDbContext _dbContext;

        public ClientRepository(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Client GetClient(Guid tenantId, Guid documentId)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.TenantId == tenantId && c.DocumentId == documentId);
        }

        public bool CheckWhiteList(Guid tenantId, int clientId)
        {
            return _dbContext.Clients.Any(c => c.TenantId == tenantId && c.ClientId == clientId && c.IsWhiteListed);
        }

        public Client GetClient(string clientVAT)
        {
            return _dbContext.Clients.FirstOrDefault(c => c.ClientVAT == clientVAT);
        }
    }
}
