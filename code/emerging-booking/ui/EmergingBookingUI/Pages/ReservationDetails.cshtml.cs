using System.Threading.Tasks;

using EmergingBookingUI.ClientServices;
using EmergingBookingUI.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergingBookingUI
{
    public class ReservationDetailsModel : PageModel
    {
        private readonly BookingReadService BookingReadService;

        public ReservationDetail Details { get; set; }

        public ReservationDetailsModel(BookingReadService bookingService)
        {
            BookingReadService = bookingService;

            Details = new ReservationDetail();
        }

        public async Task OnGet(string reservationCode)
        {
            Details = await BookingReadService.GetDetails(reservationCode);
        }
    }
}