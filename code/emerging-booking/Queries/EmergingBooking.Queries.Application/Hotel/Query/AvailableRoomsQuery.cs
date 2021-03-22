using System;

using EmergingBooking.Infrastructure.Cqrs.Queries;

namespace EmergingBooking.Queries.Application.Hotel.Query
{
    public class AvailableRoomsQuery : IQuery
    {
        public DateTime Checkin { get; }
        public DateTime Checkout { get; }

        public AvailableRoomsQuery(DateTime checkin, DateTime checkout)
        {
            Checkin = checkin;
            Checkout = checkout;
        }
    }
}