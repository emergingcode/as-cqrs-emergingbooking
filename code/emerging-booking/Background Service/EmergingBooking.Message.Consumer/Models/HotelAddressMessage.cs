using System;

namespace EmergingBooking.Message.Consumer.Models.Events
{
    public class HotelAddressChangedMessage : InternalEventBase
    {
        public Guid HotelCode { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
    }
}