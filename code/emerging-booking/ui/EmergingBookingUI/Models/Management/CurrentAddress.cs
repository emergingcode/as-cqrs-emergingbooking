using System;

namespace EmergingBookingUI.Models.Management
{
    public class CurrentAddress
    {
        public Guid HotelCode { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
    }
}