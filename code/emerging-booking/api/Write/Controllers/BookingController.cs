using System;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Infrastructure.Cqrs.Queries;
using EmergingBooking.Reservation.Application.Commands;

using EmergingBookingApi.InputModel.Booking;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergingBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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