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
        private readonly HotelWriteService HotelWriteService;
        private readonly HotelReadService HotelReadService;

        [BindProperty]
        public CurrentAddress CurrentAddress { get; set; }

        public UpdateHotelAddressModel(
            HotelWriteService hotelService,
            HotelReadService hotelReadService)
        {
            HotelWriteService = hotelService;
            HotelReadService = hotelReadService;
        }

        public async Task OnGet(Guid hotelCode)
        {
            CurrentAddress = await HotelReadService.GetCurrentAddress(hotelCode);
            CurrentAddress.HotelCode = hotelCode;
        }

        public async Task<IActionResult> OnPost()
        {
            await HotelWriteService.UpdateHotelAddress(CurrentAddress);

            return RedirectToPage("/Index", new { area = "Management" });
        }
    }
}