using System;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.Storage.RavenDB;
using EmergingBooking.Reservation.Application.Domain;

using Raven.Client.Documents;

namespace EmergingBooking.Reservation.Application.Repository
{
    internal class ReservationPersistence
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IRavenDocumentStoreHolder _ravenDocumentStore;

        public ReservationPersistence(
            IEventPublisher eventPublisher,
            IRavenDocumentStoreHolder ravenDocumentStore)
        {
            _eventPublisher = eventPublisher;
            _ravenDocumentStore = ravenDocumentStore;
        }

        internal async Task<bool> CheckAvailabilityRoomAsync(Period bookingPeriod, Guid roomCode)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                bool roomIsAvailable = await session.Query<ReservationDetail>()
                                                    .AnyAsync(reservation =>
                                                              reservation.BookedRoom.Code == roomCode &&
                                                              reservation.BookingPeriod == bookingPeriod);

                return !roomIsAvailable;
            }
        }

        internal async Task SaveReservationAsync(ReservationDetail reservation)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                await session.StoreAsync(reservation,
                                         reservation.Identifier.ToString());

                await session.SaveChangesAsync();
            }

            foreach (var @event in reservation.Events)
            {
                await _eventPublisher.PublishAsync((dynamic)@event);
            }
        }

        public async Task CancelReservation(Guid reservationIdentifier)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                session.Delete(reservationIdentifier);

                await session.SaveChangesAsync();
            }
        }
    }
}