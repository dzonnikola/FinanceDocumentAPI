using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.FinanceContext;
using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services
{
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _tenantRepository;
        public TenantService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public bool IsTenantWhiteListed(Guid tennantId)
        {
            var tenant = _tenantRepository.GetTenantById(tennantId);
            
            if (tenant == null)
            {
                return false;
            }

            return tenant.IsWhiteListed;
        }

    }
}
