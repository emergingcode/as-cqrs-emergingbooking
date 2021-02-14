using System;

using EmergingBooking.Infrastructure.Cqrs.Queries;

namespace EmergingBooking.Queries.Application.Hotel.Query
{
    public class CurrentContactsQuery : IQuery
    {
        public Guid HotelCode { get; }

        public CurrentContactsQuery(Guid hotelCode)
        {
            HotelCode = hotelCode;
        }
    }
}