using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Events
{
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
