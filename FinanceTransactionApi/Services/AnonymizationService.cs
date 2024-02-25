using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace FinanceTransactionApi.Services
{
    public class AnonymizationService : IAnonymizationService
    {
        public FinanceDocumentResponse AnonimizeData(FinanceDocumentResponse financialData, string productCode)
        {
            financialData.AccountNumber = HashString(financialData.AccountNumber);

            foreach (var item in financialData.Transactions)
            {
                item.TransactionId = MaskString(item.TransactionId);
                item.Description = MaskString(item.Description);
            }

            return financialData;
        }

        private string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        private string MaskString(string input)
        {
            return "####";
        }
    }
}
