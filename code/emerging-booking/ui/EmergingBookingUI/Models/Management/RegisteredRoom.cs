using System;
using System.Collections.Generic;

namespace EmergingBookingUI.Models.Management
{
    public class RegisteredRoom
    {
        public Guid Code { get; set; }
        public Guid HotelCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal PricePerNight { get; set; }
        public string Amenities { get; set; }

        public IEnumerable<string> AmenitiesToDisplay => Amenities.Split("|");
    }
}