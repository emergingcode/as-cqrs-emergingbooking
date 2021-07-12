using System;
using System.Data;

namespace EmergingBooking.Infrastructure.Storage.SqlServer
{
    internal class SqlServerStoreHolder : ISqlServerStoreHolder
    {
        private readonly SqlServerSettings _sqlServerSettings;
        private readonly Lazy<IDbConnection> _dbConnection;

        //public SqlServerStoreHolder(IOptions<SqlServerSettings> optionsDatabaseSettings)
        //{
        //    _sqlServerSettings = optionsDatabaseSettings.Value;
        //}

        public SqlServerStoreHolder(Lazy<IDbConnection> dbConnection)
        {
            //_sqlServerSettings = optionsDatabaseSettings.Value;
            _dbConnection = dbConnection;
        }

        //private Lazy<IDbConnection> LazyStore =>
        //    new Lazy<IDbConnection>(() => new SqlConnection(_sqlServerSettings.ConnectionString));

        public IDbConnection DbConnection => _dbConnection.Value; //azyStore.Value;
    }
}