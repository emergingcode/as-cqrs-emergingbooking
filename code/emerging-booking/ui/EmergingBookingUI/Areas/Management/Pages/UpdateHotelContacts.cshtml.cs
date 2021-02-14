namespace EmergingBookingUI.Areas.Management.Pages
{
    using System;
    using System.Threading.Tasks;

    using EmergingBookingUI.ClientServices;
    using EmergingBookingUI.Models.Management;

    using Microsoft.AspNetCore.Mvc;

    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class UpdateHotelContactsModel : PageModel

    {
        private readonly HotelService HotelService;

        [BindProperty]
        public CurrentContacts CurrentContacts { get; set; }

        public UpdateHotelContactsModel(HotelService hotelService)
        {
            HotelService = hotelService;
        }

        public async Task OnGet(Guid hotelCode)
        {
            CurrentContacts = await HotelService.GetCurrentContacts(hotelCode);
            CurrentContacts.HotelCode = hotelCode;
        }

        public async Task<IActionResult> OnPost()
        {
            await HotelService.UpdateHotelContacts(CurrentContacts);

            return RedirectToPage("/Index", new { area = "Management" });
        }
    }
}