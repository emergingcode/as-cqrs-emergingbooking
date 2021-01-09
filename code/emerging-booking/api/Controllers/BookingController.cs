using System;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Infrastructure.Cqrs.Queries;
using EmergingBooking.Queries.Application.Reservation.Query;
using EmergingBooking.Queries.Application.Reservation.ReadModel;
using EmergingBooking.Reservation.Application.Commands;

using EmergingBookingApi.InputModel.Booking;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergingBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;

        public BookingController(
            ICommandDispatcher commandDispatcher,
            IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        [Route("reservations")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> GetReservations()
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Post(RoomReservation roomReservation)
        {
            var result = await _commandDispatcher.ExecuteAsync(
                                    new MakeRoomReservation(roomReservation.HotelCode,
                                                        roomReservation.RoomCode,
                                                        roomReservation.CheckingDate,
                                                        roomReservation.CheckoutDate,
                                                        roomReservation.Guest,
                                                        roomReservation.NumberOfGuests,
                                                        roomReservation.BreakfastIncluded));

            if (result.Failure)
            {
                return UnprocessableEntity(result);
            }

            return Ok();
        }

        [HttpGet]
        [Route("{reservationCode}/detail")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReservationDetail(string reservationCode)
        {
            var retrieveReservationDetail =
                new RetrieveReservationDetail(reservationCode);

            var result = await _queryProcessor
                .ExecuteQueryAsync<RetrieveReservationDetail, ReservationDetail>(retrieveReservationDetail);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{reservationCode:guid}/cancel")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public IActionResult CancelReservation(Guid reservationCode)
        {
            _commandDispatcher.ExecuteAsync(new CancelReservation(reservationCode));

            return Ok();
        }
    }
}