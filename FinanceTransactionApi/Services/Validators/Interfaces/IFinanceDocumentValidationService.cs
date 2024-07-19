using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Validators.Interfaces
{
    /// <summary>
    /// IFinanceDocumentValidationService interface
    /// </summary>
    public interface IFinanceDocumentValidationService
    {
        /// <summary>
        /// Validates the product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        bool ValidateProductCode(string productCode);
        /// <summary>
        /// Validates the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        bool ValidateTenant(Guid tenantId);
        /// <summary>
        /// Validates the client.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <returns></returns>
        bool ValidateClient(Guid tenantId, Guid documentId);
        /// <summary>
        /// Validates the client white listing.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        bool ValidateClientWhiteListing(Guid tenantId, int clientId);
        /// <summary>
        /// Validates the type of the company.
        /// </summary>
        /// <param name="companyType">Type of the company.</param>
        /// <returns></returns>
        bool ValidateCompanyType(CompanyType companyType);

    }
}
