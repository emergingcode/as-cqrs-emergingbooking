using System.Collections.Generic;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Queries;
using EmergingBooking.Queries.Application.Hotel.Query;
using EmergingBooking.Queries.Application.Hotel.ReadModel;
using EmergingBooking.Queries.Application.Repository;

namespace EmergingBooking.Queries.Application.Hotel.Processors
{
    public class HotelQueryHandler :
        IQueryHandler<HotelQuery, IEnumerable<HotelListItem>>,
        IQueryHandler<RoomQuery, IEnumerable<RoomListItem>>,
        IQueryHandler<AvailableRoomsQuery, IEnumerable<AvailableRooms>>
    {
        private readonly HotelPersistence _hotelPersistence;

        public HotelQueryHandler(HotelPersistence hotelPersistence)
        {
            _hotelPersistence = hotelPersistence;
        }

        public async Task<IEnumerable<HotelListItem>> ExecuteQueryAsync(HotelQuery queryParameters)
        {
            return await _hotelPersistence.RetrieveHotels();
        }

        public async Task<IEnumerable<RoomListItem>> ExecuteQueryAsync(RoomQuery queryParameters)
        {
            return await _hotelPersistence.RetrieveRooms(queryParameters.HotelCode);
        }

        public async Task<IEnumerable<AvailableRooms>> ExecuteQueryAsync(AvailableRoomsQuery queryParameters)
        {
            return await _hotelPersistence.RetrieveAvailableRooms(queryParameters.Checkin, queryParameters.Checkout);
        }
    }
}