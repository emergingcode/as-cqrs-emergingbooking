using System;

using EmergingBooking.Management.Application.Domain;
using EmergingBooking.Management.Application.Domain.Events;

namespace EmergingBooking.Reservation.Application.Domain.Events
{
    internal sealed class HotelCreated : HotelEventBaseV1
    {
        private readonly Address Address;
        private readonly Contacts Contacts;

        public Guid Code { get; }
        public string Name { get; }
        public int StarsOfCategory { get; }
        public int StarsOfRating { get; }
        public string Street => Address.Street;
        public string District => Address.District;
        public string City => Address.City;
        public string Country => Address.Country;
        public int ZipCode => Address.ZipCode;
        public string Mobile => Contacts.Mobile;
        public string Phone => Contacts.Phone;
        public string Email => Contacts.Email;

        public HotelCreated(Guid code, string name, int starsOfCategory, int starsOfRating,
            Address address, Contacts contacts)
            : base(nameof(HotelCreated))
        {
            Code = code;
            Name = name;
            StarsOfCategory = starsOfCategory;
            StarsOfRating = starsOfRating;

            Address = address;
            Contacts = contacts;
        }
    }
}