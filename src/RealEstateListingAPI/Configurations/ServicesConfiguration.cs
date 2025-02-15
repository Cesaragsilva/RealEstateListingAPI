using Microsoft.AspNetCore.Mvc;
using RealEstateListing.Api.Filters;
using RealEstateListing.Application.Configure;
using RealEstateListing.Domain.Entities;
using RealEstateListing.Infrastructure.Configure;
using RealEstateListingApi.Configurations;

namespace RealEstateListingApi.Configure
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.AddModelValidationFilter<Listing>();
            })
            .AddJsonOptions(c => c.AllowInputFormatterExceptionMessages = false);

            services.AddHealthChecks();

            services.AddEndpointsApiExplorer();

            services.ConfigureApplicationServices()
                    .ConfigureInfrastructure();

            services.ConfigureSwaggerDocumentation();

            return services;
        }

        private static MvcOptions AddModelValidationFilter<T>(this MvcOptions options) where T : class
        {
            options.Filters.Add(typeof(ModelValidationFilter<T>));

            return options;
        }
    }
}
