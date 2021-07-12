using System;
using System.Data;

namespace EmergingBooking.Infrastructure.Storage.SqlServer
{
    internal class SqlServerStoreHolder : ISqlServerStoreHolder
    {
        private readonly Lazy<IDbConnection> dbConnection;

        public SqlServerStoreHolder(Lazy<IDbConnection> dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public IDbConnection DbConnection => dbConnection.Value;
    }
}