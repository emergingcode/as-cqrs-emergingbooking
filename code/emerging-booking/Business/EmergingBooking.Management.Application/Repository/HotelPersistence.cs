using System;
using System.Linq;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.Storage.RavenDB;
using EmergingBooking.Management.Application.Domain;

using Raven.Client.Documents;
using Raven.Client.Documents.Commands.Batches;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Operations;

namespace EmergingBooking.Management.Application.Repository
{
    internal class HotelPersistence
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IRavenDocumentStoreHolder _ravenDocumentStore;

        public HotelPersistence(
            IEventPublisher eventPublisher,
            IRavenDocumentStoreHolder ravenDocumentStore)
        {
            _eventPublisher = eventPublisher;
            _ravenDocumentStore = ravenDocumentStore;
        }

        internal async Task CreateHotelAsync(Hotel hotel)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                await session.StoreAsync(hotel,
                                         hotel.Identifier.ToString());

                await session.SaveChangesAsync();

                foreach (var @event in hotel.Events)
                {
                    await _eventPublisher.PublishAsync((dynamic)@event);
                }
            }
        }

        internal async Task UpdateHotelAddress(Hotel hotel)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                session.Advanced.Defer(new PatchCommandData(
                    hotel.Identifier.ToString(),
                    null,
                    new PatchRequest
                    {
                        Script = $@"this.{nameof(hotel.Address)} = args.{nameof(hotel.Address)};",
                        Values =
                        {
                            {$"{nameof(hotel.Address)}", hotel.Address}
                        }
                    },
                    null));

                await session.SaveChangesAsync();

                foreach (var @event in hotel.Events)
                {
                    await _eventPublisher.PublishAsync((dynamic)@event);
                }
            }
        }

        internal async Task UpdateHotelContacts(Hotel hotel)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                session.Advanced.Defer(new PatchCommandData(
                    hotel.Identifier.ToString(),
                    null,
                    new PatchRequest
                    {
                        Script = $@"this.{nameof(hotel.Contacts)} = args.{nameof(hotel.Contacts)};",
                        Values =
                        {
                            {$"{nameof(hotel.Contacts)}", hotel.Contacts}
                        }
                    },
                    null));

                await session.SaveChangesAsync();

                foreach (var @event in hotel.Events)
                {
                    await _eventPublisher.PublishAsync((dynamic)@event);
                }
            }
        }

        internal async Task AddRoomToHotel(Hotel hotel)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                session.Advanced.Defer(new PatchCommandData(
                    hotel.Identifier.ToString(),
                    null,
                    new PatchRequest
                    {
                        Script = $@"this.{nameof(hotel.Rooms)}.push(args.Room);",
                        Values =
                        {
                            { "Room", hotel.Rooms.ElementAt(hotel.Rooms.Count() - 1) }
                        }
                    },
                    null));

                await session.SaveChangesAsync();

                foreach (var @event in hotel.Events)
                {
                    await _eventPublisher.PublishAsync((dynamic)@event);
                }
            }
        }

        internal async Task<Hotel> RetrieveHotelByCodeAsync(Guid hotelCode)
        {
            using (var session = _ravenDocumentStore.Store.OpenAsyncSession())
            {
                var searchedHotel = await session.Query<Hotel>()
                                                 .Where(hotel => hotel.Code == hotelCode)
                                                 .FirstOrDefaultAsync();

                return searchedHotel;
            }
        }
    }
}