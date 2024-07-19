namespace FinanceTransactionApi.Models
{
    /// <summary>
    /// FinancialDocumentRequest class
    /// </summary>
    public class FinancialDocumentRequest
    {
        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        /// <value>
        /// The product code.
        /// </value>
        public string ProductCode { get; set; }
        /// <summary>
        /// Gets or sets the tenant identifier.
        /// </summary>
        /// <value>
        /// The tenant identifier.
        /// </value>
        public Guid TenantId { get; set; }
        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        public Guid DocumentId { get; set; }
    }
}
