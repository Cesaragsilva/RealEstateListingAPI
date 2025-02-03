using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RealEstateListing.Application.Interfaces.Services;
using RealEstateListing.Application.Services;
using RealEstateListing.Application.Validators;

namespace RealEstateListing.Application.Configure
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddServices()
                    .AddValidators();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IListingService, ListingService>();

            return services;
        }

        private static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ListingValidator>();

            return services;
        }
    }
}
