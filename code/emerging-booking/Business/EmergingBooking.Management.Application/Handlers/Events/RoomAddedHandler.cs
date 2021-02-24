using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.KafkaProducer;
using EmergingBooking.Management.Application.Domain.Events;
using EmergingBooking.Management.Application.Settings;

using Microsoft.Extensions.Options;

namespace EmergingBooking.Management.Application.Handlers.Events
{
    internal class RoomAddedHandler : IEventHandler<RoomAdded>
    {
        private readonly ManagementProducerSettings managementProducerSettings;

        public RoomAddedHandler(IOptions<ManagementProducerSettings> options)
        {
            managementProducerSettings = options.Value;
        }

        public async Task HandleAsync(RoomAdded @event)
        {
            using (var producer =
                new KafkaProducer<string, RoomAdded>(
                    this.managementProducerSettings.TopicName,
                    this.managementProducerSettings.Server))
            {
                await producer.ProduceMessage(@event, @event.PartitionKey());
            }
        }
    }
}