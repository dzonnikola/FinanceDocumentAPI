using FinanceTransactionApi.Models;
using Microsoft.EntityFrameworkCore;


namespace FinanceTransactionApi.FinanceContext
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FinancialDocument> FinancalDocuments { get; set; } 
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<Tenant>().HasKey(t => t.Id);

            modelBuilder.Entity<Client>().HasKey(c => c.Id);

            modelBuilder.Entity<Client>().HasOne(c=> c.FinancialDocument).WithOne().HasForeignKey<FinancialDocument>(f=> f.Id);

            modelBuilder.Entity<FinancialDocument>().HasKey(f => f.Id);

            modelBuilder.Entity<FinancialDocument>().HasMany(f => f.Transactions).WithOne().HasForeignKey(f=> f.FinnacialDocumentId);
        }

    }
}
