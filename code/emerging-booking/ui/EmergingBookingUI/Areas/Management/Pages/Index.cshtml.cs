using System.Collections.Generic;
using System.Threading.Tasks;

using EmergingBookingUI.ClientServices;
using EmergingBookingUI.Models.Management;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergingBookingUI.Areas.Management.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HotelReadService HotelReadService;

        public IEnumerable<RegisteredHotel> Hotels { get; set; }

        public IndexModel(HotelReadService hotelService)
        {
            HotelReadService = hotelService;
        }

        public async Task OnGet()
        {
            Hotels = await HotelReadService.GetRegisteredHotels();
        }
    }
}