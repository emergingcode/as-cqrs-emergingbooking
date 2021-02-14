using System;
using Dapper;

namespace EmergingBooking.Message.Consumer.Models
{
    [Table("Rooms")]
    public class RoomData
    {
        [Key]
        public Guid Code { get; set; }
        public Guid HotelCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public int AvailableQuantity { get; set; }
        public string Amenities { get; set; }
    }
}
