using FinanceTransactionApi.Models;
using FinanceTransactionApi.Services.Interfaces;
using FinanceTransactionApi.Services;
using FinanceTransactionApi.FinanceContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FinanceDbContext>(options =>
{
    options.UseInMemoryDatabase("FinanceDB");
});

builder.Services.AddScoped<DataStorage>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientInfoService, ClientInfoService>();
builder.Services.AddScoped<ICompanyTypeCheck, CompanyTypeService>();
builder.Services.AddScoped<IFinancialDocumentService, FinancialDocumentService>();
builder.Services.AddScoped<IClientInfoService, ClientInfoService>();
builder.Services.AddScoped<IAnonymizationService, AnonymizationService>();


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
