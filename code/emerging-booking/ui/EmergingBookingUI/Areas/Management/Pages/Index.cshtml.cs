using System.Collections.Generic;
using System.Threading.Tasks;

using EmergingBookingUI.ClientServices;
using EmergingBookingUI.Models.Management;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergingBookingUI.Areas.Management.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HotelService HotelService;

        public IEnumerable<RegisteredHotel> Hotels { get; set; }

        public IndexModel(HotelService hotelService)
        {
            HotelService = hotelService;
        }

        public async Task OnGet()
        {
            Hotels = await HotelService.GetRegisteredHotels();
        }
    }
}