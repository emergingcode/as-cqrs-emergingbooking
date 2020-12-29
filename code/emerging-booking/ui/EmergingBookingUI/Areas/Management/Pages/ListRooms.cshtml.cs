using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using EmergingBookingUI.ClientServices;
using EmergingBookingUI.Models.Management;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergingBookingUI.Areas.Management.Pages
{
    public class ListRoomsModel : PageModel
    {
        private readonly HotelService HotelService;
        public IEnumerable<RegisteredRoom> Rooms { get; set; }

        public Guid HotelCode { get; set; }

        public ListRoomsModel(HotelService hotelService)
        {
            HotelService = hotelService;
        }

        public async Task OnGet(Guid hotelCode)
        {
            Rooms = await HotelService.GetRegisteredRooms(hotelCode);
            HotelCode = hotelCode;
        }
    }
}