namespace FinanceTransactionApi.Models
{
    /// <summary>
    /// Tenant class
    /// </summary>
    public class Tenant
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is white listed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is white listed; otherwise, <c>false</c>.
        /// </value>
        public bool IsWhiteListed { get; set; }
    }
}
