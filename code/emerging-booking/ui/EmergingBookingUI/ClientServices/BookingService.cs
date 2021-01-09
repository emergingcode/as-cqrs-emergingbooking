using System;
using System.Net.Http;
using System.Threading.Tasks;

using EmergingBookingUI.Models;

namespace EmergingBookingUI.ClientServices
{
    public class BookingService
    {
        private readonly HttpClient ReservationClient;

        public BookingService(HttpClient client)
        {
            ReservationClient = client;
        }

        internal async Task<HttpResponseMessage> BookRoom(Guid hotelCode,
            Guid roomCode,
            string checkin,
            string checkout,
            string guestName,
            int numberOfGuests,
            bool breakfastIncluded)
        {
            try
            {
                var response = await ReservationClient.PostAsJsonAsync(ClientServiceEndpoints.BookingEndpoints.BookRoom, new
                {
                    HotelCode = hotelCode,
                    RoomCode = roomCode,
                    CheckingDate = checkin,
                    CheckoutDate = checkout,
                    Guest = guestName,
                    NumberOfGuests = numberOfGuests,
                    BreakfastIncluded = breakfastIncluded
                });

                return response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<ReservationDetail> GetDetails(string reservationCode)
        {
            try
            {
                var relativePathEndpoint =
                    string.Format(ClientServiceEndpoints.BookingEndpoints.ReservationDetails, reservationCode);

                var response = await ReservationClient.GetAsync(relativePathEndpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<ReservationDetail>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}