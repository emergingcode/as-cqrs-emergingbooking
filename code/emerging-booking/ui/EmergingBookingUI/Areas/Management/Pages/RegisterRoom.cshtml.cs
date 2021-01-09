using System;
using System.Threading.Tasks;

using EmergingBookingUI.ClientServices;
using EmergingBookingUI.Models.Management;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergingBookingUI.Areas.Management.Pages
{
    public class RegisterRoomModel : PageModel
    {
        private readonly HotelService HotelService;

        [BindProperty]
        public RoomForRegistring NewRoom { get; set; }

        public Guid HotelCode { get; set; }

        public RegisterRoomModel(HotelService hotelService)
        {
            HotelService = hotelService;
        }

        public void OnGet(Guid hotelCode)
        {
            HotelCode = hotelCode;
        }

        public async Task<IActionResult> OnPost(Guid hotelCode)
        {
            await HotelService.RegisterRoom(hotelCode, NewRoom);

            return RedirectToPage("/Index", new { area = "Management" });
        }
    }
}