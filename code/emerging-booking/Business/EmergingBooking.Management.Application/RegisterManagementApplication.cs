using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.Storage.RavenDB;
using EmergingBooking.Management.Application.Commands;
using EmergingBooking.Management.Application.Domain.Events;
using EmergingBooking.Management.Application.Handlers;
using EmergingBooking.Management.Application.Handlers.Events;
using EmergingBooking.Management.Application.Repository;
using EmergingBooking.Management.Application.Settings;
using EmergingBooking.Reservation.Application.Domain.Events;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmergingBooking.Management.Application
{
    public static class RegisterManagementApplication
    {
        public static IServiceCollection RegisterManagementApplicationDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddOptions<ManagementProducerSettings>()
                    .Bind(configuration.GetSection(nameof(ManagementProducerSettings)));

            services.RegisterRavenDBStorageInfrastructureDependencies(configuration);

            services.AddTransient<ICommandHandler<CreateHotel>, CreateHotelHandler>();
            services.AddTransient<ICommandHandler<UpdateHotelAddress>, UpdateHotelAddressHandler>();
            services.AddTransient<ICommandHandler<UpdateHotelContacts>, UpdateHotelContactsHandler>();
            services.AddTransient<ICommandHandler<AddRoomToHotel>, AddRoomToHotelHandler>();

            services.AddTransient<IEventHandler<HotelCreated>, HotelCreatedHandler>();
            services.AddTransient<IEventHandler<HotelAddressUpdated>, HotelAddressUpdatedHandler>();
            services.AddTransient<IEventHandler<HotelContactsUpdated>, HotelContactsUpdatedHandler>();
            services.AddTransient<IEventHandler<RoomAdded>, RoomAddedHandler>();

            services.AddTransient<HotelPersistence, HotelPersistence>();

            return services;
        }
    }
}