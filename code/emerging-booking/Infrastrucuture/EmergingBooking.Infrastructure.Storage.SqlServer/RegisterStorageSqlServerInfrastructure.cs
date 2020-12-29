using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmergingBooking.Infrastructure.Storage.SqlServer
{
    public static class RegisterStorageSqlServerInfrastructure
    {
        public static IServiceCollection RegisterSqlServerInfrastructureDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<SqlServerSettings>()
                    .Bind(configuration.GetSection(nameof(SqlServerSettings)));

            services.AddTransient<ISqlServerStoreHolder, SqlServerStoreHolder>();

            return services;
        }
    }
}