using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EmergingBookingUI.ClientServices;
using EmergingBookingUI.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergingBookingUI
{
    public class AvailableRoomsModel : PageModel
    {
        private readonly HotelReadService HotelReadService;
        private readonly BookingWriteService BookingWriteService;

        [BindProperty(SupportsGet = true)]
        public DateTime SearchChecking { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime SearchCheckout { get; set; }

        public IEnumerable<AvailableRooms> AvailableRooms { get; set; }

        public AvailableRoomsModel(
            HotelReadService hotelReadService,
            BookingWriteService bookingService)
        {
            HotelReadService = hotelReadService;
            BookingWriteService = bookingService;

            AvailableRooms = Enumerable.Empty<AvailableRooms>();
        }

        public async Task OnGetAvailableRooms()
        {
            AvailableRooms = await HotelReadService.GetAvailableRooms(SearchChecking, SearchCheckout);
        }

        public async Task OnPostBookThisRoom(
            Guid hotelCode,
            Guid roomCode,
            string checkin,
            string checkout,
            string guestName,
            int numberOfGuests,
            bool breakfastIncluded)
        {
            await BookingWriteService.BookRoom(
                hotelCode,
                roomCode,
                checkin,
                checkout,
                guestName,
                numberOfGuests,
                breakfastIncluded);
        }
    }
}