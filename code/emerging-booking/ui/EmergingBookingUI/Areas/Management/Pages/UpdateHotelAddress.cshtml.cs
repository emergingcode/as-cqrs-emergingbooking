namespace EmergingBookingUI.Areas.Management.Pages
{
    using System;
    using System.Threading.Tasks;

    using EmergingBookingUI.ClientServices;
    using EmergingBookingUI.Models.Management;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class UpdateHotelAddressModel : PageModel
    {
        private readonly HotelService HotelService;

        [BindProperty]
        public CurrentAddress CurrentAddress { get; set; }

        public UpdateHotelAddressModel(HotelService hotelService)
        {
            HotelService = hotelService;
        }

        public async Task OnGet(Guid hotelCode)
        {
            CurrentAddress = await HotelService.GetCurrentAddress(hotelCode);
            CurrentAddress.HotelCode = hotelCode;
        }

        public async Task<IActionResult> OnPost()
        {
            await HotelService.UpdateHotelAddress(CurrentAddress);

            return RedirectToPage("/Index", new { area = "Management" });
        }
    }
}