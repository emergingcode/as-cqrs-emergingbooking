using System;

namespace EmergingBooking.Message.Consumer.Models.Events
{
    public class HotelContactsChangedMessage : InternalEventBase
    {
        public Guid HotelCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
    }
}