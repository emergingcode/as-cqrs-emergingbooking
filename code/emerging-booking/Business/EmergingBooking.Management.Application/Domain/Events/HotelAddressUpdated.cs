using System;

namespace EmergingBooking.Management.Application.Domain.Events
{
    internal sealed class HotelAddressUpdated : HotelEventBaseV1
    {
        public Guid HotelCode { get; }
        public string Street { get; }
        public string District { get; }
        public string City { get; }
        public string Country { get; }
        public int ZipCode { get; }

        public HotelAddressUpdated(Guid hotelCode, string street, string district,
            string city, string country, int zipCode)
            : base(nameof(HotelAddressUpdated))
        {
            HotelCode = hotelCode;
            Street = street;
            District = district;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }
    }
}