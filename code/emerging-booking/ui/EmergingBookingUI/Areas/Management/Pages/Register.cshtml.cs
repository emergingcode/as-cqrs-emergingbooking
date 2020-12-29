namespace EmergingBookingUI.Areas.Management.Pages
{
    using System.Threading.Tasks;

    using EmergingBookingUI.ClientServices;
    using EmergingBookingUI.Models.Management;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class RegisterModel : PageModel
    {
        private readonly HotelService HotelService;

        [BindProperty]
        public HotelForRegistring NewHotel { get; set; }

        public RegisterModel(HotelService hotelService)
        {
            HotelService = hotelService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            await HotelService.Register(NewHotel);

            return RedirectToPage("/Index", new { area = "Management" });
        }
    }
}