using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using EmergingBookingUI.Models;
using EmergingBookingUI.Models.Management;

namespace EmergingBookingUI.ClientServices
{
    public class HotelService
    {
        private readonly HttpClient HotelClient;

        public HotelService(HttpClient client)
        {
            HotelClient = client;
        }

        public async Task<IEnumerable<RegisteredRoom>> GetRegisteredRooms(Guid hotelCode)
        {
            try
            {
                var relativePathEndpoint = string.Format(ClientServiceEndpoints.HotelEndpoints.ListRegisteredRooms, hotelCode);
                var response = await HotelClient.GetAsync(relativePathEndpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<IReadOnlyCollection<RegisteredRoom>>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        internal async Task<IEnumerable<AvailableRooms>> GetAvailableRooms(DateTime checking, DateTime checkout)
        {
            try
            {
                var relativePathEndpoint = string.Format(ClientServiceEndpoints.HotelEndpoints.AvailableRooms, checking, checkout);
                var response = await HotelClient.GetAsync(relativePathEndpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<IReadOnlyCollection<AvailableRooms>>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        internal async Task<HttpResponseMessage> RegisterRoom(Guid hotelCode, RoomForRegistring newRoom)
        {
            try
            {
                var relativePathEndpoint = string.Format(ClientServiceEndpoints.HotelEndpoints.RegisterRoom, hotelCode);
                var response = await HotelClient.PostAsJsonAsync(relativePathEndpoint, newRoom);

                return response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<RegisteredHotel>> GetRegisteredHotels()
        {
            try
            {
                var response = await HotelClient.GetAsync(ClientServiceEndpoints.HotelEndpoints.ListRegisteredHotels);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsAsync<IReadOnlyCollection<RegisteredHotel>>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        internal async Task<HttpResponseMessage> Register(HotelForRegistring newHotel)
        {
            try
            {
                var response = await HotelClient.PostAsJsonAsync(ClientServiceEndpoints.HotelEndpoints.Register, newHotel);

                return response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}