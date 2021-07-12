using System;
using System.Threading.Tasks;

using Dapper;

using EmergingBooking.Infrastructure.Storage.SqlServer;
using EmergingBooking.Message.Consumer.Models;

namespace EmergingBooking.Message.Consumer.Repository
{
    internal class ReservationPersistenceSynchronizer : RepositoryBase
    {
        public ReservationPersistenceSynchronizer(ISqlServerStoreHolder sqlServerStoreHolder)
            : base(sqlServerStoreHolder)
        {
        }

        public async Task SynchronizeReservationData(ReservationData reservationData)
        {
            await HandleConnection(async (connection) =>
            {
                return await connection.InsertAsync<Guid, ReservationData>(reservationData);
            });
        }
    }
}