using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.KafkaProducer;
using EmergingBooking.Management.Application.Domain.Events;
using EmergingBooking.Management.Application.Settings;
using EmergingBooking.Reservation.Application.Domain.Events;

using Microsoft.Extensions.Options;

namespace EmergingBooking.Management.Application.Handlers.Events
{
    internal class HotelCreatedHandler : IEventHandler<HotelCreated>
    {
        private readonly ManagementProducerSettings managementProducerSettings;

        public HotelCreatedHandler(IOptions<ManagementProducerSettings> options)
        {
            managementProducerSettings = options.Value;
        }

        public async Task HandleAsync(HotelCreated @event)
        {
            try
            {
                using (var producer =
                        new KafkaProducer<string, HotelEventBaseV1>(
                            this.managementProducerSettings.TopicName,
                            this.managementProducerSettings.Server))
                {
                    await producer.ProduceMessage(@event, @event.PartitionKey());
                }
            }
            catch
            {
                throw;
            }
        }
    }
}