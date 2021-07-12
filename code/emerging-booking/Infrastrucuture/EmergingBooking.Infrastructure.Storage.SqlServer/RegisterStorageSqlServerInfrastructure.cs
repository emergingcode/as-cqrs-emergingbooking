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

            //services.AddSingleton<Lazy<IDbConnection>, Lazy<IDbConnection>>(provider =>
            //{
            //    var _sqlServerSettings = provider.GetRequiredService<IOptions<SqlServerSettings>>().Value;

            //    return new Lazy<IDbConnection>(() => new SqlConnection(_sqlServerSettings.ConnectionString));
            //});

            services.AddSingleton<ISqlServerStoreHolder, SqlServerStoreHolder>();

            return services;
        }
    }
}