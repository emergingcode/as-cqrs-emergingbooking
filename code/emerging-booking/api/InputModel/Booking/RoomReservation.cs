using System;

namespace EmergingBookingApi.InputModel.Booking
{
    public class RoomReservation
    {
        public Guid HotelCode { get; set; }
        public Guid RoomCode { get; set; }
        public DateTime CheckingDate { get; set; }
        public DateTime CheckoutDate { get; set; }
        public string Guest { get; set; }
        public bool BreakfastIncluded { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
