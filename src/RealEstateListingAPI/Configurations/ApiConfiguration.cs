using RealEstateListing.Api.Middlewares;
using RealEstateListingApi.Configurations;

namespace RealEstateListing.Api.Configurations
{
    public static class ApiConfiguration
    {
        public static WebApplication ConfigureApi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerConfiguration();
            }

            app.UseMiddleware<ExceptionMiddleware>()
               .UseHealthChecks("/health")
               .UseHttpsRedirection()
               .UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
