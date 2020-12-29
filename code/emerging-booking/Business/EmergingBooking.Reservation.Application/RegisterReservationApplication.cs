using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Infrastructure.Cqrs.Events;
using EmergingBooking.Infrastructure.Storage.RavenDB;
using EmergingBooking.Reservation.Application.Commands;
using EmergingBooking.Reservation.Application.Domain.Events;
using EmergingBooking.Reservation.Application.Handlers;
using EmergingBooking.Reservation.Application.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmergingBooking.Reservation.Application
{
    public static class RegisterReservationApplication
    {
        public static IServiceCollection RegisterReservationApplicationDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.RegisterRavenDBStorageInfrastructureDependencies(configuration);

            services.AddTransient<ICommandHandler<MakeRoomReservation>, ReservationHandler>();
            services.AddTransient<ICommandHandler<CancelReservation>, ReservationHandler>();

            services.AddTransient<IEventHandler<ReservationCreated>, ReservationCreatedHandler>();

            services.AddTransient<ReservationPersistence, ReservationPersistence>();
            services.AddTransient<HotelPersistence, HotelPersistence>();

            return services;
        }
    }
}