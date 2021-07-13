using System;

namespace EmergingBooking.Management.Application.Domain.Events
{
    internal sealed class HotelContactsUpdated : HotelEventBaseV1
    {
        public Guid HotelCode { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Mobile { get; }

        public HotelContactsUpdated(Guid hotelCode, string email, string phone,
            string mobile)
            : base(nameof(HotelContactsUpdated))
        {
            HotelCode = hotelCode;
            Email = email;
            Phone = phone;
            Mobile = mobile;
        }
    }
}