using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.KafkaProducer;
using EmergingBooking.Reservation.Application.Domain.Events;
using EmergingBooking.Reservation.Application.Settings;

using Microsoft.Extensions.Options;

namespace EmergingBooking.Reservation.Application.Handlers.Events
{
    internal class ReservationCreatedHandler : IEventHandler<ReservationCreated>
    {
        private readonly ReservationProducerSettings reservationProducerSettings;

        public ReservationCreatedHandler(IOptions<ReservationProducerSettings> options)
        {
            reservationProducerSettings = options.Value;
        }

        public async Task HandleAsync(ReservationCreated @event)
        {
            using (var producer =
                new KafkaProducer<string, ReservationEventBaseV1>(
                    this.reservationProducerSettings.TopicName,
                    this.reservationProducerSettings.Server))
            {
                await producer.ProduceMessage(@event, @event.PartitionKey());
            }
        }
    }
}