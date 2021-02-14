using System;
using System.Collections.Generic;

namespace EmergingBookingApi.InputModel.Management
{
    public class HotelRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal PricePerNight { get; set; }
        public List<string> Amenities { get; set; }

        public HotelRoom()
        {
            Amenities = new List<string>();
        }
    }
}