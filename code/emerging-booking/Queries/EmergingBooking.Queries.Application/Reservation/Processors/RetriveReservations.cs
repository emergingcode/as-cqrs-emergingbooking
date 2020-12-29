using System;
using EmergingBooking.Infrastructure.Cqrs.Queries;

namespace EmergingBooking.Queries.Application.Reservation.Query
{
    public class RetrieveReservations : IQuery
    {
        public Guid RoomId { get; }

        public RetrieveReservations(Guid roomId)
        {
            RoomId = roomId;
        }
    }
}
