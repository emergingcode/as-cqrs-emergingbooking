using System;

namespace EmergingBooking.Reservation.Application.Domain.Events
{
    internal class ReservationCreated : ReservationEventBaseV1
    {
        public ReservationCreated(
            string code,
            string bookedBy,
            int numberOfGuests,
            int numberOfNights,
            decimal paidPrice,
            bool breakfastIncluded,
            Period bookingPeriod,
            BookedHotel bookedHotel,
            BookedRoom bookedRoom) : base(nameof(ReservationCreated))
        {
            Code = code;
            BookedBy = bookedBy;
            NumberOfGuests = numberOfGuests;
            NumberOfNights = numberOfNights;
            PaidPrice = paidPrice;
            BreakfastIncluded = breakfastIncluded;
            BookingPeriod = bookingPeriod;
            BookedHotel = bookedHotel;
            BookedRoom = bookedRoom;
        }

        private Period BookingPeriod { get; }
        private BookedHotel BookedHotel { get; }
        private BookedRoom BookedRoom { get; }

        public string Code { get; }
        public string BookedBy { get; }
        public int NumberOfGuests { get; }
        public int NumberOfNights { get; }
        public decimal PaidPrice { get; }
        public bool BreakfastIncluded { get; }
        public string HotelName => BookedHotel.Name;
        public string HotelAddress => BookedHotel.Address;
        public int HotelStarsOfCategory => BookedHotel.StarsOfCategory;
        public DateTime Checkin => BookingPeriod.Checkin;
        public DateTime Checkout => BookingPeriod.Checkout;
        public Guid RoomCode => BookedRoom.Code;
        public string RoomDescription => BookedRoom.Description;
        public int RoomCapacity => BookedRoom.Capacity;
        public decimal PricePerNight => BookedRoom.PricePerNight;
    }
}