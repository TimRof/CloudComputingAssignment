using Entities.Models.Listing;
using Entities.Models.Mortgage;
using Entities.Models.User;
using Repository;
using Repository.Mortgage;
using ServiceLayer.Listing;
using ServiceLayer.Mortgage;
using ServiceLayer.User;
using WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServiceExtensions.ConfigureListingContext(builder.Services, builder.Configuration);
ServiceExtensions.ConfigureUserContext(builder.Services, builder.Configuration);
ServiceExtensions.ConfigureMortgageApplicationContext(builder.Services, builder.Configuration);

builder.Services.AddScoped<ICustomerService<Customer>, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<IListingService<PropertyListing>, PropertyListingService>();
builder.Services.AddScoped<IPropertyListingRepository, PropertyListingRepository>();

builder.Services.AddScoped<IMortgageApplicationService<MortgageApplication>, MortgageApplicationService>();
builder.Services.AddScoped<IMortgageOfferService<MortgageOffer>, MortgageOfferService>();
builder.Services.AddScoped<IMortgageRepository, MortgageRepository>();

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