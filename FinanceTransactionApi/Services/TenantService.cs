using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;

namespace FinanceTransactionApi.Services
{
    public class TenantService : ITenantService
    {
        private readonly FinanceDbContext _dbContext;

        public TenantService(FinanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsTenantWhiteListed(Guid tennantId)
        {
            var tenant = _dbContext.Tenants.FirstOrDefault(t => t.Id == tennantId);
            
            if (tenant == null)
            {
                return false;
            }

            return tenant.IsWhiteListed;
        }

    }
}
