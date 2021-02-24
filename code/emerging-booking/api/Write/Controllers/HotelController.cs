using System;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Infrastructure.Cqrs.Queries;
using EmergingBooking.Management.Application.Commands;

using EmergingBookingApi.InputModel.Management;

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

        //[HttpGet("")]
        //[ProducesResponseType(typeof(IEnumerable<HotelListItem>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetHotels()
        //{
        //    var result = await _queryProcessor.ExecuteQueryAsync<HotelQuery, IEnumerable<HotelListItem>>(new HotelQuery());
        //    return Ok(result);
        //}

        //[HttpGet("{hotelCode:guid}/rooms")]
        //[ProducesResponseType(typeof(IEnumerable<RoomListItem>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Get(Guid hotelCode)
        //{
        //    var result = await _queryProcessor.ExecuteQueryAsync<RoomQuery, IEnumerable<RoomListItem>>(new RoomQuery(hotelCode));
        //    return Ok(result);
        //}

        //[HttpGet("{hotelCode:guid}/address/current")]
        //[ProducesResponseType(typeof(CurrentAddress), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetCurrentAddress(Guid hotelCode)
        //{
        //    var result = await _queryProcessor
        //        .ExecuteQueryAsync<CurrentAddressQuery, CurrentAddress>(new CurrentAddressQuery(hotelCode));
        //    return Ok(result);
        //}

        //[HttpGet("{hotelCode:guid}/contacts/current")]
        //[ProducesResponseType(typeof(CurrentContacts), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetCurrentContacts(Guid hotelCode)
        //{
        //    var result = await _queryProcessor
        //        .ExecuteQueryAsync<CurrentContactsQuery, CurrentContacts>(new CurrentContactsQuery(hotelCode));
        //    return Ok(result);
        //}

        //[HttpGet("available-rooms")]
        //[ProducesResponseType(typeof(IEnumerable<AvailableRooms>), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetAvailableRooms(DateTime checking, DateTime checkout)
        //{
        //    var result = await _queryProcessor.ExecuteQueryAsync<AvailableRoomsQuery, IEnumerable<AvailableRooms>>(new AvailableRoomsQuery(checking, checkout));
        //    return Ok(result);
        //}

        [HttpPost("")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> RegisterHotel(Hotel hotel)
        {
            var result = await _commandDispatcher.ExecuteAsync(
                            new CreateHotel(hotel.Name,
                                            hotel.StarsOfCategory,
                                            hotel.Street,
                                            hotel.District,
                                            hotel.City,
                                            hotel.Country,
                                            hotel.Zipcode,
                                            hotel.Email,
                                            hotel.Phone,
                                            hotel.Mobile));

            if (result.Failure)
            {
                return UnprocessableEntity(result);
            }

            return Created("", result);
        }

        //[HttpPut]
        //[ProducesResponseType(typeof(CommandResult), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        //public async Task<IActionResult> Put(Guid hotelCode, Hotel hotel)
        //{
        //    var result = await _commandDispatcher.ExecuteAsync(
        //                    new UpdateHotel(hotelCode,
        //                                hotel.Name,
        //                                hotel.StarsOfCategory,
        //                                hotel.Street,
        //                                hotel.District,
        //                                hotel.City,
        //                                hotel.Country,
        //                                hotel.Zipcode,
        //                                hotel.Email,
        //                                hotel.Phone,
        //                                hotel.Mobile));

        //    if (result.Failure)
        //    {
        //        return UnprocessableEntity(result);
        //    }

        //    return Created("", result);
        //}

        [HttpPut("{hotelCode:guid}/address/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> UpdateHotelAddress(Guid hotelCode, HotelAddress hotelAddress)
        {
            var result = await _commandDispatcher.ExecuteAsync(
                new UpdateHotelAddress(hotelCode,
                                       hotelAddress.Street,
                                       hotelAddress.District,
                                       hotelAddress.City,
                                       hotelAddress.Country,
                                       hotelAddress.Zipcode));

            if (result.Failure)
            {
                return UnprocessableEntity(result);
            }

            return NoContent();
        }

        [HttpPut("{hotelCode:guid}/contacts/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> UpdateHotelContacts(Guid hotelCode, HotelContacts hotelContacts)
        {
            var result = await _commandDispatcher.ExecuteAsync(
                new UpdateHotelContacts(hotelCode,
                                        hotelContacts.Email,
                                        hotelContacts.Phone,
                                        hotelContacts.Mobile));

            if (result.Failure)
            {
                return UnprocessableEntity(result);
            }

            return NoContent();
        }

        [HttpPost("{hotelCode:guid}/room")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> AddHotelRoom(Guid hotelCode, [FromBody] HotelRoom hotelRoom)
        {
            var result = await _commandDispatcher.ExecuteAsync(
                new AddRoomToHotel(hotelCode,
                                   hotelRoom.Name,
                                   hotelRoom.Description,
                                   hotelRoom.Capacity,
                                   hotelRoom.AvailableQuantity,
                                   hotelRoom.PricePerNight,
                                   hotelRoom.Amenities));

            if (result.Failure)
            {
                return UnprocessableEntity(result);
            }

            return NoContent();
        }
    }
}