using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTransactionApi.Controllers
{
    /// <summary>
    /// FinancialDocumentController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialDocumentController : ControllerBase
    {
        /// <summary>
        /// The financial document service
        /// </summary>
        private readonly IFinancialDocumentService _financialDocumentService;
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
        /// The client information service
        /// </summary>
        private readonly IClientInfoService _clientInfoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialDocumentController"/> class.
        /// </summary>
        /// <param name="financialDocumentService">The financial document service.</param>
        /// <param name="productService">The product service.</param>
        /// <param name="tenantService">The tenant service.</param>
        /// <param name="clientService">The client service.</param>
        /// <param name="clientInfoService">The client information service.</param>
        public FinancialDocumentController(
        IFinancialDocumentService financialDocumentService,
        IProductService productService,
        ITenantService tenantService,
        IClientService clientService,
        IClientInfoService clientInfoService
        )
        {
            _financialDocumentService = financialDocumentService;
            _productService = productService;
            _tenantService = tenantService;
            _clientService = clientService;
            _clientInfoService = clientInfoService;
        }


        /// <summary>
        /// Retrieves the financial document.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost("retrieve")]
        public IActionResult RetrieveFinancialDocument([FromBody] FinancialDocumentRequest request)
        {
            try
            {
                // Validate the request model
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Validate product code
                if (!_productService.IsProductValid(request.ProductCode))
                {
                    return StatusCode(403, "Product is not valid!");
                }

                // Validate tenant ID
                if (!_tenantService.IsTenantWhiteListed(request.TenantId))
                {
                    return StatusCode(403, "Tenant not whitelisted");
                }

                // Get client information and check whitelisting
                var clientInfo = _clientService.GetClientDetails(request.TenantId, request.DocumentId);
                if (clientInfo == null)
                {
                    return StatusCode(403, "Bad client info!");
                }

                if(!_clientService.IsClientWhiteListed(request.TenantId, clientInfo.ClientId))
                {
                    return StatusCode(403, "Client not whitelisted");
                }

                // Fetch additional client information
                var additionalInfo = _clientInfoService.GetAditionalInfo(clientInfo.ClientVAT);

                // Check company type
                if (additionalInfo.companyType == CompanyType.Small)
                {
                    return StatusCode(403, "Company type is small");
                }

                // Retrieve financial document
                var financialDocument = _financialDocumentService.GetFinancialDocument(request.TenantId, request.DocumentId, request.ProductCode);

                if(financialDocument == null)
                {
                    return StatusCode(403, "Product code is not valid with Document!");
                }

                // Enrich response model
                var enrichedResponse = new FinancialDataResponse
                {
                    Data = new FinanceDocumentResponse
                    {
                        AccountNumber = financialDocument.Data.AccountNumber,
                        Balance = financialDocument.Data.Balance,
                        Currency = financialDocument.Data.Currency,
                        Transactions = financialDocument.Data.Transactions
                    },
                    Company = new CompanyResponse
                    {
                        RegistrationNumber = additionalInfo.RegistrationNumber,
                        CompanyType = additionalInfo.companyType.ToString()
                    }
                };

                return Ok(enrichedResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
