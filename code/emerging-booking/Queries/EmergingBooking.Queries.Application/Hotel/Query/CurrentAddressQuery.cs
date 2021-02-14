using System;

using EmergingBooking.Infrastructure.Cqrs.Queries;

namespace EmergingBooking.Queries.Application.Hotel.Query
{
    public class CurrentAddressQuery : IQuery
    {
        public Guid HotelCode { get; }

        public CurrentAddressQuery(Guid hotelCode)
        {
            HotelCode = hotelCode;
        }
    }
}