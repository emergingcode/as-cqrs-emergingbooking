using System;

namespace EmergingBooking.Queries.Application.Hotel.ReadModel
{
    public class HotelListItem
    {
        public Guid Code { get; set; }
        public string Name { get; set; }
        public int StarsOfCategory { get; set; }
        public int StarsOfRating { get; set; }
        public string AddressStreet { get; set; }
        public string AddressDistrict { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public int ZipCode { get; set; }
        public string ContactMobile { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public int Rooms { get; set; }
    }
}