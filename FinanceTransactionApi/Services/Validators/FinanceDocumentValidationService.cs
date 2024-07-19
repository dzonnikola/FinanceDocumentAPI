using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.Services.Validators.Interfaces;

namespace FinanceTransactionApi.Services.Validators
{
    /// <summary>
    /// FinanceDocumentValidationService class
    /// </summary>
    /// <seealso cref="FinanceTransactionApi.Services.Validators.Interfaces.IFinanceDocumentValidationService" />
    public class FinanceDocumentValidationService : IFinanceDocumentValidationService
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService _productService;
        /// <summary>
        /// The tenant service
        /// </summary>
        private readonly ITenantService _tenantService;
        /// <summary>
        /// The client service
        /// </summary>
        private readonly IClientService _clientService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinanceDocumentValidationService"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="clientService">The client service.</param>
        public FinanceDocumentValidationService(
        IProductService productService,
        ITenantService tenantService,
        IClientService clientService
            ) {
            _clientService = clientService;
            _tenantService = tenantService;
            _productService = productService;        
        }
        /// <summary>
        /// Validates the product code.
        /// </summary>
        /// <param name="productCode">The product code.</param>
        /// <returns></returns>
        public bool ValidateProductCode(string productCode)
        {
            return _productService.IsProductValid(productCode);
        }

        /// <summary>
        /// Validates the tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        public bool ValidateTenant(Guid tenantId)
        {
            return _tenantService.IsTenantWhiteListed(tenantId);
        }

        /// <summary>
        /// Validates the client.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="documentId">The document identifier.</param>
        /// <returns></returns>
        public bool ValidateClient(Guid tenantId, Guid documentId)
        {
            var clientInfo = _clientService.GetClientDetails(tenantId, documentId);
            return clientInfo != null;
        }

        /// <summary>
        /// Validates the client white listing.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        public bool ValidateClientWhiteListing(Guid tenantId, int clientId)
        {
            return _clientService.IsClientWhiteListed(tenantId, clientId);
        }
        /// <summary>
        /// Validates the type of the company.
        /// </summary>
        /// <param name="companyType">Type of the company.</param>
        /// <returns></returns>
        public bool ValidateCompanyType(CompanyType companyType)
        {
            return companyType != CompanyType.Small;
        }
    }
}
