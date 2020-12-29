using System;
using System.Threading.Tasks;

using Dapper;

using EmergingBooking.Infrastructure.Storage.SqlServer;
using EmergingBooking.Message.Consumer.Models;

namespace EmergingBooking.Message.Consumer.Repository
{
    public class ReservationPersistenceSynchronizer
    {
        private readonly ISqlServerStoreHolder _sqlServerStoreHolder;

        public ReservationPersistenceSynchronizer(ISqlServerStoreHolder sqlServerStoreHolder)
        {
            _sqlServerStoreHolder = sqlServerStoreHolder;
        }

        public async Task SynchronizeReservationData(ReservationData reservationData)
        {
            try
            {
                using (var connection = _sqlServerStoreHolder.DbConnection)
                {
                    connection.Open();

                    await connection.InsertAsync<Guid, ReservationData>(reservationData);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}