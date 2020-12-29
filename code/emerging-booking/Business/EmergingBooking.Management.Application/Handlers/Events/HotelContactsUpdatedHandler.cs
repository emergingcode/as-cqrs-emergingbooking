using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.KafkaProducer;
using EmergingBooking.Reservation.Application.Domain.Events;

namespace EmergingBooking.Management.Application.Handlers.Events
{
    internal class HotelContactsUpdatedHandler : IEventHandler<HotelContactsUpdated>
    {
        public async Task HandleAsync(HotelContactsUpdated @event)
        {
            using (var producer =
                new KafkaProducer<string, HotelContactsUpdated>(
                    "dev.emergingbooking.management.hotel-events",
                    "kafkaserver:9092"))
            {
                await producer.ProduceMessage(@event, @event.PartitionKey());
            }
        }
    }
}