using System;
using System.Threading.Tasks;

using Dapper;

using EmergingBooking.Infrastructure.Storage.SqlServer;
using EmergingBooking.Message.Consumer.DataModels;
using EmergingBooking.Message.Consumer.Models;

namespace EmergingBooking.Message.Consumer.Repository
{
    public class HotelPersistenceSynchronizer
    {
        private readonly ISqlServerStoreHolder _sqlServerStoreHolder;

        public HotelPersistenceSynchronizer(ISqlServerStoreHolder sqlServerStoreHolder)
        {
            _sqlServerStoreHolder = sqlServerStoreHolder;
        }

        public async Task SynchronizeHotelData(HotelData hotelData)
        {
            try
            {
                using (var connection = _sqlServerStoreHolder.DbConnection)
                {
                    connection.Open();

                    await connection.InsertAsync<Guid, HotelData>(hotelData);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SynchronizeHotelAddressData(HotelAddressData hotelAddressData)
        {
            try
            {
                using (var connection = _sqlServerStoreHolder.DbConnection)
                {
                    connection.Open();

                    await connection.UpdateAsync(hotelAddressData);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SynchronizeHotelContactsData(HotelContactsData hotelContactsData)
        {
            try
            {
                using (var connection = _sqlServerStoreHolder.DbConnection)
                {
                    connection.Open();

                    await connection.UpdateAsync(hotelContactsData);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SynchronizeRoomData(RoomData roomData)
        {
            try
            {
                using (var connection = _sqlServerStoreHolder.DbConnection)
                {
                    connection.Open();

                    await connection.InsertAsync<Guid, RoomData>(roomData);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}