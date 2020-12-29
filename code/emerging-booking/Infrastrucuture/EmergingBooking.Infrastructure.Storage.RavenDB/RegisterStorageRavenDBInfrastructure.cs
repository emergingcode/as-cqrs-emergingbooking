using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmergingBooking.Infrastructure.Storage.RavenDB
{
    public static class RegisterStorageRavenDBInfrastructure
    {
        public static IServiceCollection RegisterRavenDBStorageInfrastructureDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<RavenDBSettings>()
                    .Bind(configuration.GetSection(nameof(RavenDBSettings)));
            
            services.AddTransient<IRavenDocumentStoreHolder, RavenDocumentStoreHolder>();

            return services;
        }
    }
}