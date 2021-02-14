using System.Threading.Tasks;

using EmergingBookingUI.ClientServices;
using EmergingBookingUI.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmergingBookingUI
{
    public class ReservationDetailsModel : PageModel
    {
        private readonly BookingService BookingService;

        public ReservationDetail Details { get; set; }

        public ReservationDetailsModel(
            HotelService hotelService,
            BookingService bookingService)
        {
            BookingService = bookingService;

            Details = new ReservationDetail();
        }

        public async Task OnGet(string reservationCode)
        {
            Details = await BookingService.GetDetails(reservationCode);
        }
    }
}