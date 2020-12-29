using System;

namespace EmergingBookingApi.InputModel.Management
{
    public class HotelAddress
    {
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Zipcode { get; set; }
    }
}