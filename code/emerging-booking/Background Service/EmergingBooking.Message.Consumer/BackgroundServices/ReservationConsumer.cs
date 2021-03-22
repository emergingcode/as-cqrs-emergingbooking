using System;
using System.Threading;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.KafkaConsumer;
using EmergingBooking.Message.Consumer.Converters;
using EmergingBooking.Message.Consumer.Extensions;
using EmergingBooking.Message.Consumer.Models.Events;
using EmergingBooking.Message.Consumer.Repository;

using Microsoft.Extensions.Hosting;

namespace EmergingBooking.Message.Consumer.BackgroundServices
{
    public class ReservationConsumer : BackgroundService
    {
        private readonly ReservationPersistenceSynchronizer _reservationPersistenceSynchronizer;

        public ReservationConsumer(
            ReservationPersistenceSynchronizer reservationPersistenceSynchronizer)
        {
            _reservationPersistenceSynchronizer = reservationPersistenceSynchronizer;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await ConsumeRoomMessage();

                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }

        private async Task ConsumeRoomMessage()
        {
            var consumer = new KafkaConsumer<string, InternalEventBase>("hotel-consumer-group",
                                                                        "kafkaserver:9092",
                                                                        "dev-emergingbooking-reservation-booking-events",
                                                                        new ReservationEventConverter())
            {
                OnConsumingAsync = OnRoomConsumingAsync
            };

            var cancellationToken = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cancellationToken.Cancel();
            };

            await consumer.ConsumeAsync(cancellationToken);
        }

        private async Task OnRoomConsumingAsync(InternalEventBase reservationEventMessage)
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