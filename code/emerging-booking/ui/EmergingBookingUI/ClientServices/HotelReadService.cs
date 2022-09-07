using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using EmergingBookingUI.Models;
using EmergingBookingUI.Models.Management;

namespace EmergingBookingUI.ClientServices
{
    public class HotelReadService
    {
        private readonly HttpClient HotelClient;

        public HotelReadService(HttpClient client)
        {
            HotelClient = client;
        }

        internal async Task<IEnumerable<RegisteredRoom>> GetRegisteredRooms(Guid hotelCode)
        {
            try
            {
                var relativePathEndpoint = string.Format(ClientServiceEndpoints.HotelEndpoints.ListRegisteredRooms, hotelCode);
                var response = await HotelClient.GetAsync(relativePathEndpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<IReadOnlyCollection<RegisteredRoom>>();
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

                return await response.Content.ReadFromJsonAsync<IReadOnlyCollection<AvailableRooms>>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        internal async Task<IEnumerable<RegisteredHotel>> GetRegisteredHotels()
        {
            try
            {
                var response = await HotelClient.GetAsync(ClientServiceEndpoints.HotelEndpoints.ListRegisteredHotels);

                response.EnsureSuccessStatusCode();


                return await response.Content.ReadFromJsonAsync<IEnumerable<RegisteredHotel>>();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        internal async Task<CurrentAddress> GetCurrentAddress(Guid hotelCode)
        {
            try
            {
                var relativePathEndpoint = string.Format(ClientServiceEndpoints.HotelEndpoints.CurrentAddress, hotelCode);
                var response = await HotelClient.GetAsync(relativePathEndpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<CurrentAddress>() ?? new CurrentAddress();
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }

        internal async Task<CurrentContacts> GetCurrentContacts(Guid hotelCode)
        {
            try
            {
                var relativePathEndpoint = string.Format(ClientServiceEndpoints.HotelEndpoints.CurrentContacts, hotelCode);
                var response = await HotelClient.GetAsync(relativePathEndpoint);

                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<CurrentContacts>() ?? new CurrentContacts() ;
            }
            catch (HttpRequestException ex)
            {
                throw ex;
            }
        }
    }
}