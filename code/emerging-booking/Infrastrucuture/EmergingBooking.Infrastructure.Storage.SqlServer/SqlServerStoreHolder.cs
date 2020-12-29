using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace EmergingBooking.Infrastructure.Storage.SqlServer
{
    internal class SqlServerStoreHolder : ISqlServerStoreHolder
    {
        private readonly SqlServerSettings _sqlServerSettings;

        public SqlServerStoreHolder(IOptions<SqlServerSettings> optionsDatabaseSettings)
        {
            _sqlServerSettings = optionsDatabaseSettings.Value;
        }

        private Lazy<IDbConnection> LazyStore => 
            new Lazy<IDbConnection>(() => new SqlConnection(_sqlServerSettings.ConnectionString));
        

        public IDbConnection DbConnection => LazyStore.Value;
    }
}
