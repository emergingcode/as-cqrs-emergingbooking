using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Infrastructure.Cqrs.Queries;
using EmergingBooking.Queries.Application.Hotel.Query;
using EmergingBooking.Queries.Application.Hotel.ReadModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmergingBookingApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandDispatcher _commandDispatcher;

        public HotelController(
            ICommandDispatcher commandDispatcher,
            IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<HotelListItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetHotels()
        {
            var result = await _queryProcessor.ExecuteQueryAsync<HotelQuery, IEnumerable<HotelListItem>>(new HotelQuery());
            return Ok(result);
        }

        [HttpGet("{hotelCode:guid}/rooms")]
        [ProducesResponseType(typeof(IEnumerable<RoomListItem>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid hotelCode)
        {
            var result = await _queryProcessor.ExecuteQueryAsync<RoomQuery, IEnumerable<RoomListItem>>(new RoomQuery(hotelCode));
            return Ok(result);
        }

        [HttpGet("{hotelCode:guid}/address/current")]
        [ProducesResponseType(typeof(CurrentAddress), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentAddress(Guid hotelCode)
        {
            var result = await _queryProcessor
                .ExecuteQueryAsync<CurrentAddressQuery, CurrentAddress>(new CurrentAddressQuery(hotelCode));
            return Ok(result);
        }

        [HttpGet("{hotelCode:guid}/contacts/current")]
        [ProducesResponseType(typeof(CurrentContacts), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentContacts(Guid hotelCode)
        {
            var result = await _queryProcessor
                .ExecuteQueryAsync<CurrentContactsQuery, CurrentContacts>(new CurrentContactsQuery(hotelCode));
            return Ok(result);
        }

        [HttpGet("available-rooms")]
        [ProducesResponseType(typeof(IEnumerable<AvailableRooms>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAvailableRooms(DateTime checking, DateTime checkout)
        {
            var result = await _queryProcessor.ExecuteQueryAsync<AvailableRoomsQuery, IEnumerable<AvailableRooms>>(new AvailableRoomsQuery(checking, checkout));
            return Ok(result);
        }
    }
}