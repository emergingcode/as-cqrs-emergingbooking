using System;

namespace EmergingBooking.Message.Consumer.Models.Events
{
    public class InternalEventBase
    {
        public string EventName { get; set; }

        public Guid EventId { get; set; }

        public string Version { get; set; }

        public DateTime OccuredAt { get; set; }
    }
}