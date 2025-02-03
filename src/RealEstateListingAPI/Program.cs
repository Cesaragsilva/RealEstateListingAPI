using RealEstateListing.Api.Configurations;
using RealEstateListingApi.Configure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

var app = builder.Build();

app.ConfigureApi();
app.Run();
