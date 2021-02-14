using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.KafkaProducer;
using EmergingBooking.Management.Application.Domain.Events;
using EmergingBooking.Reservation.Application.Domain.Events;

namespace EmergingBooking.Management.Application.Handlers.Events
{
    internal class HotelCreatedHandler : IEventHandler<HotelCreated>
    {
        public async Task HandleAsync(HotelCreated @event)
        {
            try
            {
                using (var producer =
                        new KafkaProducer<string, HotelEventBaseV1>(
                            "dev-emergingbooking-management-hotel-events",
                            "kafkaserver:9092"))
                {
                    await producer.ProduceMessage(@event, @event.PartitionKey());
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}