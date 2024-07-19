using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.Services.Validators;
using FinanceTransactionApi.Services.Validators.Interfaces;
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
        /// The financial document validator
        /// </summary>
        private readonly IFinanceDocumentValidationService _financialDocumentValidator;

        /// <summary>
        /// The client information service
        /// </summary>
        private readonly IClientInfoService _clientInfoService;
        /// <summary>
        /// The client service
        /// </summary>
        private readonly IClientService _clientService;


        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialDocumentController" /> class.
        /// </summary>
        /// <param name="financialDocumentService">The financial document service.</param>
        /// <param name="financeDocumentValidationService">The finance document validation service.</param>
        /// <param name="clientInfoService">The client information service.</param>
        /// <param name="clientService">The client service.</param>
        public FinancialDocumentController(
        IFinancialDocumentService financialDocumentService,
        IFinanceDocumentValidationService financeDocumentValidationService,
        IClientInfoService clientInfoService,
        IClientService clientService
        )
        {
            _financialDocumentService = financialDocumentService;
            _financialDocumentValidator = financeDocumentValidationService;
            _clientInfoService = clientInfoService;
            _clientService = clientService;
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!_financialDocumentValidator.ValidateProductCode(request.ProductCode))
                {
                    return BadRequest(request.ProductCode + " is not a valid product code");
                }

                if (!_financialDocumentValidator.ValidateTenant(request.TenantId))
                {
                    return Unauthorized("Tenant is not whitelisted");
                }

                var clientInfo = _clientService.GetClientDetails(request.TenantId, request.DocumentId);
                if (clientInfo == null)
                {
                    return NotFound("Client not found");
                }

                if (!_financialDocumentValidator.ValidateClientWhiteListing(request.TenantId, clientInfo.ClientId))
                {
                    return Forbid("Client is not whitelisted");
                }

                var additionalInfo = _clientInfoService.GetAditionalInfo(clientInfo.ClientVAT);

                if (!_financialDocumentValidator.ValidateCompanyType(additionalInfo.companyType))
                {
                    return Forbid("Company type is small");
                }

                var financialDocument = _financialDocumentService.GetFinancialDocument(request.TenantId, request.DocumentId, request.ProductCode);
                if (financialDocument == null)
                {
                    return NotFound("Financial document not found");
                }

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
