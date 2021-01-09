using System;
using EmergingBooking.Infrastructure.Cqrs.Commands;

namespace EmergingBooking.Reservation.Application.Commands
{
    public class MakeRoomReservation : ICommand
    {
        public MakeRoomReservation(Guid hotelCode, Guid roomCode, DateTime checkingDate,
            DateTime checkoutDate, string guest, int numberOfGuests, bool breakfastIncluded)
        {
            HotelCode = hotelCode;
            RoomCode = roomCode;
            CheckingDate = checkingDate;
            CheckoutDate = checkoutDate;
            Guest = guest;
            NumberOfGuests = numberOfGuests;
            BreakfastIncluded = breakfastIncluded;
        }

        public Guid HotelCode { get; }
        public Guid RoomCode { get; }
        public DateTime CheckingDate { get; }
        public DateTime CheckoutDate { get; }
        public string Guest { get; }
        public int NumberOfGuests { get; }
        public bool BreakfastIncluded { get; }
    }
}
