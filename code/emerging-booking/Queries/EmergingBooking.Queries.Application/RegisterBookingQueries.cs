using System.Collections.Generic;

using EmergingBooking.Infrastructure.Cqrs.Queries;
using EmergingBooking.Infrastructure.Storage.SqlServer;
using EmergingBooking.Queries.Application.Hotel.Processors;
using EmergingBooking.Queries.Application.Hotel.Query;
using EmergingBooking.Queries.Application.Hotel.ReadModel;
using EmergingBooking.Queries.Application.Repository;
using EmergingBooking.Queries.Application.Reservation.Processors;
using EmergingBooking.Queries.Application.Reservation.Query;
using EmergingBooking.Queries.Application.Reservation.ReadModel;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmergingBooking.Queries.Application
{
    public static class RegisterBookingQueries
    {
        public static IServiceCollection RegisterQueriesApplicationDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.RegisterSqlServerInfrastructureDependencies(configuration);

            services.AddTransient<IQueryHandler<RetrieveReservationDetail, ReservationDetail>, RetrieveReservationDetailHandler>();
            services.AddTransient<IQueryHandler<HotelQuery, IEnumerable<HotelListItem>>, HotelQueryHandler>();
            services.AddTransient<IQueryHandler<AvailableRoomsQuery, IEnumerable<AvailableRooms>>, HotelQueryHandler>();
            services.AddTransient<IQueryHandler<RoomQuery, IEnumerable<RoomListItem>>, HotelQueryHandler>();
            services.AddTransient<IQueryHandler<CurrentAddressQuery, CurrentAddress>, HotelQueryHandler>();
            services.AddTransient<IQueryHandler<CurrentContactsQuery, CurrentContacts>, HotelQueryHandler>();

            services.AddSingleton<ReservationPersistence, ReservationPersistence>();
            services.AddSingleton<HotelPersistence, HotelPersistence>();

            return services;
        }
    }
}