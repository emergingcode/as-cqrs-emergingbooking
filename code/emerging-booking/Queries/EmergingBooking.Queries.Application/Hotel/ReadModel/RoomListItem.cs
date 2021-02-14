using System;
namespace EmergingBooking.Queries.Application.Hotel.ReadModel
{
    public class RoomListItem
    {
        public Guid Code { get; set; }
        public Guid HotelCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int AvailableQuantity { get; set; }
        public decimal PricePerNight { get; set; }
        public string Amenities { get; set; }
    }
}
