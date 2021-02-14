using System;

namespace EmergingBookingUI.Models
{
    public class AvailableRooms
    {
        public Guid HotelCode { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public int StarsOfCategory { get; set; }
        public Guid RoomCode { get; set; }
        public string RoomName { get; set; }
        public DateTime UnavailableDateFrom { get; set; }
        public DateTime UnavailableDateTo { get; set; }
        public int Availability { get; set; }
    }
}