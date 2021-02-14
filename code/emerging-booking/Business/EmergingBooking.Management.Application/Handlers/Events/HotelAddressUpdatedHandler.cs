using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.KafkaProducer;
using EmergingBooking.Reservation.Application.Domain.Events;

namespace EmergingBooking.Management.Application.Handlers.Events
{
    internal class HotelAddressUpdatedHandler : IEventHandler<HotelAddressUpdated>
    {
        public async Task HandleAsync(HotelAddressUpdated @event)
        {
            using (var producer =
                new KafkaProducer<string, HotelAddressUpdated>(
                    "dev-emergingbooking-management-hotel-events",
                    "kafkaserver:9092"))
            {
                await producer.ProduceMessage(@event, @event.PartitionKey());
            }
        }
    }
}