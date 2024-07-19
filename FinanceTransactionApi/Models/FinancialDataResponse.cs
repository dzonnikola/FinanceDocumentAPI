using Newtonsoft.Json;

namespace FinanceTransactionApi.Models
{
    /// <summary>
    /// FinancialDataResponse class
    /// </summary>
    public class FinancialDataResponse
    {
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public FinanceDocumentResponse Data { get; set; }
        /// <summary>
        /// Gets or sets the company.
        /// </summary>
        /// <value>
        /// The company.
        /// </value>
        public CompanyResponse Company { get; set; }
    }
}
