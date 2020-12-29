using System;
using EmergingBooking.Infrastructure.Cqrs.Commands;

namespace EmergingBooking.Management.Application.Commands
{
    public class UpdateHotelAddress : ICommand
    {
        public Guid HotelCode { get; }
        public string NewStreet { get; }
        public string NewDistrict { get; }
        public string NewCity { get; }
        public string NewCountry { get; }
        public int NewZipcode { get; }

        public UpdateHotelAddress(Guid hotelCode, string newStreet, string newDistrict,
            string newCity, string newCountry, int newZipcode)
        {
            HotelCode = hotelCode;
            NewStreet = newStreet;
            NewDistrict = newDistrict;
            NewCity = newCity;
            NewCountry = newCountry;
            NewZipcode = newZipcode;
        }
    }
}
