using System.Threading.Tasks;

namespace EmergingBooking.Infrastructure.Cqrs.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}