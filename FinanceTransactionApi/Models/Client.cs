namespace FinanceTransactionApi.Models
{
    /// <summary>
    /// Client class
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the client identifier.
        /// </summary>
        /// <value>
        /// The client identifier.
        /// </value>
        public int ClientId { get; set; }
        /// <summary>
        /// Gets or sets the client vat.
        /// </summary>
        /// <value>
        /// The client vat.
        /// </value>
        public string ClientVAT { get; set; }
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public Guid TenantId { get; set; }
        /// <summary>
        /// Gets or sets the registration number.
        /// </summary>
        /// <value>
        /// The registration number.
        /// </value>
        public string RegistrationNumber { get; set; }
        public bool IsWhiteListed { get; set; }
        /// <summary>
        /// Gets or sets the type of the company.
        /// </summary>
        /// <value>
        /// The type of the company.
        /// </value>
        public CompanyType CompanyType { get; set; }
        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        public Guid DocumentId { get; set; }
        /// <summary>
        /// Gets or sets the financial document.
        /// </summary>
        /// <value>
        /// The financial document.
        /// </value>
        public FinancialDocument FinancialDocument { get; set; }

    }
}
