using System;
using System.Threading;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.KafkaConsumer;
using EmergingBooking.Message.Consumer.Converters;
using EmergingBooking.Message.Consumer.Extensions;
using EmergingBooking.Message.Consumer.Models.Events;
using EmergingBooking.Message.Consumer.Repository;
using EmergingBooking.Message.Consumer.Settings;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace EmergingBooking.Message.Consumer.BackgroundServices
{
    public class ReservationConsumer : BackgroundService
    {
        private readonly ReservationConsumerSettings _reservationConsumerSettings;
        private readonly ReservationPersistenceSynchronizer _reservationPersistenceSynchronizer;

        public ReservationConsumer(
            ReservationPersistenceSynchronizer reservationPersistenceSynchronizer,
            IOptions<ReservationConsumerSettings> options)
        {
            _reservationConsumerSettings = options.Value;
            _reservationPersistenceSynchronizer = reservationPersistenceSynchronizer;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await ConsumeReservationMessage();

                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }

        private async Task ConsumeReservationMessage()
        {
            var consumer = new KafkaConsumer<string, InternalEventBase>(_reservationConsumerSettings.GroupName,
                                                                        _reservationConsumerSettings.Server,
                                                                        _reservationConsumerSettings.TopicName,
                                                                        new ReservationEventConverter())
            {
                OnConsumingAsync = OnReservationConsumingAsync
            };

            var cancellationToken = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cancellationToken.Cancel();
            };

            await consumer.ConsumeAsync(cancellationToken);
        }

        private async Task OnReservationConsumingAsync(InternalEventBase reservationEventMessage)
        {
            switch (reservationEventMessage)
            {
                case ReservationCreatedMessage reservationCreatedMessage:
                    Console.WriteLine($"The processed event was {nameof(reservationCreatedMessage)}");
                    await _reservationPersistenceSynchronizer.SynchronizeReservationData(reservationCreatedMessage.ParserTo());
                    return;

                default:
                    throw new ArgumentException(
                        message: "Event is not a recognized as valid",
                        paramName: nameof(reservationEventMessage));
            }
        }
    }
}