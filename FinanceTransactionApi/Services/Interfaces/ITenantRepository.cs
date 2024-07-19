using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    public interface ITenantRepository
    {
        Tenant GetTenantById(Guid tenant);
    }
}
