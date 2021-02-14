using System;

using EmergingBooking.Infrastructure.Cqrs.Queries;

namespace EmergingBooking.Queries.Application.Hotel.Query
{
    public class RoomQuery : IQuery
    {
        public Guid HotelCode { get; }

        public RoomQuery(Guid hotelCode)
        {
            HotelCode = hotelCode;
        }
    }
}