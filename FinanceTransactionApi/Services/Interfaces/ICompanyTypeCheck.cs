using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.Services.Interfaces
{
    /// <summary>
    /// ICompanyTypeCheck interface
    /// </summary>
    public interface ICompanyTypeCheck
    {
        /// <summary>
        /// Determines whether [is company small] [the specified company type].
        /// </summary>
        /// <param name="companyType">Type of the company.</param>
        /// <returns>
        ///   <c>true</c> if [is company small] [the specified company type]; otherwise, <c>false</c>.
        /// </returns>
        bool IsCompanySmall(CompanyType companyType);
    }
}
