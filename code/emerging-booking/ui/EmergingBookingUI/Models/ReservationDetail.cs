using System;

namespace EmergingBookingUI.Models
{
    public class ReservationDetail
    {
        public string Code { get; set; }
        public string BookedBy { get; set; }
        public int NumberOfGuests { get; set; }
        public int NumberOfNights { get; set; }
        public decimal PaidPrice { get; set; }
        public bool BreakfastIncluded { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public int HotelStarsOfCategory { get; set; }
        public string RoomDescription { get; set; }
        public int RoomCapacity { get; set; }
        public decimal PricePerNight { get; set; }
    }
}