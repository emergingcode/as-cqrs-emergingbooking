using System.Collections.Generic;

namespace EmergingBookingUI.Models.Management
{
    public class RoomForRegistring
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal PricePerNight { get; set; }
        public List<string> Amenities { get; set; }

        public RoomForRegistring()
        {
            Amenities = new List<string>();
        }
    }
}