using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    /// <summary>
    /// IClientService interface
    /// </summary>
    public interface IClientService
    {
        /// <summary>
        /// Gets the client details.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <returns></returns>
        Client GetClientDetails(Guid tenantId, Guid documentId);
        /// <summary>
        /// Determines whether [is client white listed] [the specified tenant identifier].
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is client white listed] [the specified tenant identifier]; otherwise, <c>false</c>.
        /// </returns>
        bool IsClientWhiteListed(Guid tenantId, int clientId);
    }
}
