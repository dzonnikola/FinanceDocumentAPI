using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.Services;
using FinanceTransactionApi.FinanceContext;
using Microsoft.EntityFrameworkCore;
using FinanceTransactionApi.Services.Validators;
using FinanceTransactionApi.Services.Validators.Interfaces;
using FinanceTransactionApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinanceDbContext>(options =>
{
    options.UseInMemoryDatabase("FinanceDB");
});

builder.Services.AddScoped<DataStorage>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped< IClientService, ClientService>();
builder.Services.AddScoped<IFinancialDocumentRepository, FinancialDocumentRepository>();
builder.Services.AddScoped<IFinancialDocumentService, FinancialDocumentService>();
builder.Services.AddScoped<IClientInfoService, ClientInfoService>();
builder.Services.AddScoped<ICompanyTypeCheck, CompanyTypeService>();
builder.Services.AddScoped<IAnonymizationService, AnonymizationService>();
builder.Services.AddScoped<IFinanceDocumentValidationService, FinanceDocumentValidationService>();


using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();
    DataStorage.PopulateProductData(dbContext);
    DataStorage.PopulateTenantData(dbContext);
    DataStorage.PopulateClientData(dbContext);
    DataStorage.PopulateFinancialDocumentData(dbContext);
}
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
