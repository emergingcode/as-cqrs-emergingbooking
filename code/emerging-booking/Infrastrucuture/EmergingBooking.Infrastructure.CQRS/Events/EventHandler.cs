using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Events
{
    public abstract class EventHandler<TEvent> : IEventHandler<TEvent>
        where TEvent : IEvent
    {
        public abstract Task HandleAsync(TEvent @event);
    }
}
