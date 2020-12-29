using System;
using EmergingBooking.Infrastructure.Cqrs.Commands;

namespace EmergingBooking.Reservation.Application.Commands
{
    public class CancelReservation : ICommand
    {
        public Guid ReservationCode { get; }

        public CancelReservation(Guid reservationCode)
        {
            ReservationCode = reservationCode;
        }
    }
}
