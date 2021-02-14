using System.Threading.Tasks;
using EmergingBooking.Infrastructure.Cqrs.Queries;
using EmergingBooking.Queries.Application.Repository;
using EmergingBooking.Queries.Application.Reservation.Query;
using EmergingBooking.Queries.Application.Reservation.ReadModel;

namespace EmergingBooking.Queries.Application.Reservation.Processors
{
    internal class RetrieveReservationDetailHandler :
        IQueryHandler<RetrieveReservationDetail, ReservationDetail>,
        IQueryHandler<RetrieveReservations, ReservationDetail[]>
    {
        private readonly ReservationPersistence _reservationPersistence;

        public RetrieveReservationDetailHandler(ReservationPersistence reservationPersistence)
        {
            _reservationPersistence = reservationPersistence;
        }

        public async Task<ReservationDetail> ExecuteQueryAsync(
            RetrieveReservationDetail queryParameters)
        {
            return await _reservationPersistence
                .RetrieveReservationDetail(queryParameters.ReservationCode);
        }

        public Task<ReservationDetail[]> ExecuteQueryAsync(RetrieveReservations queryParameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
