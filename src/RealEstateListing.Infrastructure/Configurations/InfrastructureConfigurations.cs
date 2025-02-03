using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RealEstateListing.Application.Interfaces.Repositories;
using RealEstateListing.Infrastructure.Data.Context;
using RealEstateListing.Infrastructure.Data.Repository;

namespace RealEstateListing.Infrastructure.Configure
{
    public static class InfrastructureConfigurations
    {
        public static IServiceCollection ConfigureInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext()
                    .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("RealEstateListings"));

            return services;
        }
    }
}
