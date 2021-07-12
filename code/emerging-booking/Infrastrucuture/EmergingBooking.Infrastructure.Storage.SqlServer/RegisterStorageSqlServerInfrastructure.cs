using System;
using System.Data;
using System.Data.SqlClient;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

            services.AddSingleton<Lazy<IDbConnection>, Lazy<IDbConnection>>(provider =>
            {
                var _sqlServerSettings = provider.GetRequiredService<IOptions<SqlServerSettings>>().Value;

                return new Lazy<IDbConnection>(() =>
                {
                    var t = new SqlConnection(_sqlServerSettings.ConnectionString);
                    t.ConnectionString = _sqlServerSettings.ConnectionString;
                    return t;
                });
            });

            services.AddSingleton<ISqlServerStoreHolder, SqlServerStoreHolder>();

            return services;
        }
    }
}