using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.KafkaProducer;
using EmergingBooking.Reservation.Application.Domain.Events;

namespace EmergingBooking.Reservation.Application.Handlers
{
    internal class ReservationCreatedHandler : IEventHandler<ReservationCreated>
    {
        public async Task HandleAsync(ReservationCreated @event)
        {
            using (var producer =
                new KafkaProducer<string, ReservationEventBaseV1>(
                    "dev-emergingbooking-reservation-booking-events",
                    "kafkaserver:9092"))
            {
                await producer.ProduceMessage(@event, @event.PartitionKey());
            }
        }
    }
}