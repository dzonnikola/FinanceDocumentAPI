namespace FinanceTransactionApi.Models
{
    /// <summary>
    /// FinanceDocumentResponse class
    /// </summary>
    public class FinanceDocumentResponse
    {
        /// <summary>
        /// Gets or sets the account number.
        /// </summary>
        /// <value>
        /// The account number.
        /// </value>
        public string? AccountNumber { get; set; }
        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal? Balance { get; set; }
        /// <summary>
        /// Gets or sets the currency.
        /// </summary>
        /// <value>
        /// The currency.
        /// </value>
        public string? Currency { get; set; }
        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>
        /// The transactions.
        /// </value>
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
