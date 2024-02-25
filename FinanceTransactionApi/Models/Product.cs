namespace FinanceTransactionApi.Models
{
    /// <summary>
    /// Product class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        /// <value>
        /// The product code.
        /// </value>
        public string ProductCode { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is supported.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is supported; otherwise, <c>false</c>.
        /// </value>
        public bool IsSupported { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [hashed configuration].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [hashed configuration]; otherwise, <c>false</c>.
        /// </value>
        public bool HashedConfiguration { get; set; }
    }
}
