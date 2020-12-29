using System;

namespace EmergingBooking.Message.Consumer.Models.Events
{
    internal class HotelCreatedMessage : InternalEventBase
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public int StarsOfCategory { get; set; }
        public int StarsOfRating { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}