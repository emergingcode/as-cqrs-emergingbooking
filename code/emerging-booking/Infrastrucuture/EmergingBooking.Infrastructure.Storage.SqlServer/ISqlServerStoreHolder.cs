using System.Data;

namespace EmergingBooking.Infrastructure.Storage.SqlServer
{
    public interface ISqlServerStoreHolder
    {
        IDbConnection DbConnection { get; }
    }
}