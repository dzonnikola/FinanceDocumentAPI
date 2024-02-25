namespace FinanceTransactionApi.Services.Interfaces
{
    /// <summary>
    /// ITenantService interface
    /// </summary>
    public interface ITenantService
    {
        /// <summary>
        /// Determines whether [is tenant white listed] [the specified tennant identifier].
        /// </summary>
        /// <param name="tennantId">The tennant identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is tenant white listed] [the specified tennant identifier]; otherwise, <c>false</c>.
        /// </returns>
        bool IsTenantWhiteListed(Guid tennantId);
    }
}
