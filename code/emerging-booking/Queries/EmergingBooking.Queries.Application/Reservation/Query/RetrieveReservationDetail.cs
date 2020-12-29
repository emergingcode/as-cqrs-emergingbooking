using EmergingBooking.Infrastructure.Cqrs.Queries;

namespace EmergingBooking.Queries.Application.Reservation.Query
{
    public class RetrieveReservationDetail : IQuery
    {
        public string ReservationCode { get; }

        public RetrieveReservationDetail(string reservationCode)
        {
            ReservationCode = reservationCode;
        }
    }
}