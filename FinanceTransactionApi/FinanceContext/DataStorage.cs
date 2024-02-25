using FinanceTransactionApi.Models;

namespace FinanceTransactionApi.FinanceContext
{
    public class DataStorage
    {
        public static void PopulateProductData(FinanceDbContext context)
        {
            var product1 = new Product { Id = 1, ProductCode = "ProductA", IsSupported = true, HashedConfiguration = true };
            var product2 = new Product { Id = 2, ProductCode = "ProductB", IsSupported = false, HashedConfiguration = true };
            var product3 = new Product { Id = 3, ProductCode = "ProductC", IsSupported = true, HashedConfiguration = false };

            context.Products.AddRange(product1, product2, product3);
            context.SaveChanges();
        }

        public static void PopulateTenantData(FinanceDbContext context)
        {
            var tenant1 = new Tenant { Id = Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"), Name = "Tenant1", IsWhiteListed = true };
            var tenant2 = new Tenant { Id = Guid.Parse("22fd7565-4457-4569-a375-255405719be8"), Name = "Tenant2", IsWhiteListed = false };

            context.Tenants.AddRange(tenant1, tenant2);
            context.SaveChanges();
        }

        public static void PopulateClientData(FinanceDbContext context)
        {
            var client1 = new Client { Id = Guid.Parse("9b03a1e5-52be-472f-9fde-ba5cb25ebc2b"), ClientId = 1, ClientVAT = "100109821", DocumentId = Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126"), TenantId = Guid.Parse("9ba59611-3f09-43ee-a660-d2e5d5539aed"), CompanyType = CompanyType.Large, RegistrationNumber = "10023412", IsWhiteListed = true};
            var client2 = new Client { Id = Guid.Parse("3e9359fd-a40c-43ff-8f43-ca31d47bf31a"), ClientId = 2, ClientVAT = "112787732", DocumentId = Guid.Parse("8e3354a4-6a71-42b0-9055-d9d4903e19a8"), TenantId = Guid.Parse("22fd7565-4457-4569-a375-255405719be8"), CompanyType = CompanyType.Medium, RegistrationNumber = "10023412", IsWhiteListed = false};

            context.Clients.AddRange(client1, client2);
            context.SaveChanges();
        }

        public static void PopulateFinancialDocumentData(FinanceDbContext context)
        {
            var finDoc1 =
            new FinancialDocument
            {
                Id = Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126"),
                AccountNumber = "250-00123456-78",
                Balance = 100000,
                Currency = "EUR",
                ClientId = Guid.Parse("9b03a1e5-52be-472f-9fde-ba5cb25ebc2b"),
                ProductCode = "ProductA",
                Transactions = new List<Transaction>()
                {
                     new Transaction
                        {
                            TransactionId = "0001",
                            Amount = 1000,
                            Date = DateTime.Now.Date,
                            Category = "Hrana",
                            Description = "Poslovna večera",

                            FinnacialDocumentId = Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126")
                        },
                        new Transaction
                        {
                            TransactionId = "0002",
                            Amount = 5000,
                            Date = DateTime.Now.Date,
                            Category = "Odeća",
                            Description = "Oprema za skijanje",

                            FinnacialDocumentId = Guid.Parse("7d3cb2b0-0eb8-4a72-aaed-224ebd8ae126")
                        }
                }
            };

            var finDoc2 =
                new FinancialDocument
                {
                    Id = Guid.Parse("8e3354a4-6a71-42b0-9055-d9d4903e19a8"),
                    AccountNumber = "250-00123456-63",
                    Balance = 200000,
                    Currency = "RSD",
                    ClientId = Guid.Parse("3e9359fd-a40c-43ff-8f43-ca31d47bf31a"),
                    ProductCode = "ProductB",
                    Transactions = new List<Transaction>()
                    {
                        new Transaction
                        {
                            TransactionId = "1234",
                            Amount = 6000,
                            Date = DateTime.Now.Date,
                            Category = "Kredit",
                            Description = "Rata kredita - Referentni broj kredita : 000--1110",

                            FinnacialDocumentId = Guid.Parse("8e3354a4-6a71-42b0-9055-d9d4903e19a8")
                        },
                         new Transaction
                        {
                            TransactionId = "2345",
                            Amount = 3000,
                            Date = DateTime.Now.Date,
                            Category = "Hrana",
                            Description = "Poslovna večera sa klijentom",
                            FinnacialDocumentId = Guid.Parse("8e3354a4-6a71-42b0-9055-d9d4903e19a8")
                        }
                    },
                };

            context.FinancalDocuments.AddRange(finDoc1, finDoc2);
            context.SaveChanges();

        }
    }
}
