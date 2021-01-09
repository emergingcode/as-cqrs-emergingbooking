using System;

namespace EmergingBooking.Infrastructure.Cqrs.Events
{
    public class EventBase : IEvent
    {
        public EventBase(string eventName, string version)
        {
            EventName = eventName;
            Version = version;
            OccuredAt = DateTime.UtcNow;
        }

        public string EventName { get; }

        public Guid EventId => Guid.NewGuid();

        public string Version { get; }

        public DateTime OccuredAt { get; }
    }
}