using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    /// <summary>
    /// IClientInfoService interface
    /// </summary>
    public interface IClientInfoService
    {
        /// <summary>
        /// Gets the aditional information.
        /// </summary>
        /// <param name="clientVAT">The client vat.</param>
        /// <returns></returns>
        (string RegistrationNumber, CompanyType companyType) GetAditionalInfo(string clientVAT);
    }
}
