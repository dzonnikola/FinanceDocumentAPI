using FinanceTransactionApi.FinanceContext;
using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;

namespace FinanceTransactionApi.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly FinanceDbContext _dbContext;

        public TenantRepository(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Tenant GetTenantById(Guid tenantId)
        {
            return _dbContext.Tenants.Where(t => t.Id == tenantId).FirstOrDefault();  
        }
    }
}
