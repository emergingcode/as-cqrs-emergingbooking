using System;
using System.Collections.Generic;

namespace EmergingBooking.Message.Consumer.Models.Events
{
    public class RoomAddedMessage : InternalEventBase
    {
        public Guid Code { get; set; }
        public Guid HotelCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
        public int AvailableQuantity { get; set; }
        public IReadOnlyList<string> Amenities { get; set; }
    }
}