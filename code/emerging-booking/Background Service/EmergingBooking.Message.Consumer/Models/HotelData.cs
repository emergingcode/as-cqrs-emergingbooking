using System;

using Dapper;

namespace EmergingBooking.Message.Consumer.DataModels
{
    [Table("Hotels")]
    public class HotelData
    {
        [Key]
        public Guid Code { get; set; }

        public string Name { get; set; }
        public int StarsOfCategory { get; set; }
        public int StarsOfRating { get; set; }

        [Column("AddressStreet")]
        public string Street { get; set; }

        [Column("AddressDistrict")]
        public string District { get; set; }

        [Column("AddressCity")]
        public string City { get; set; }

        [Column("AddressCountry")]
        public string Country { get; set; }

        public int ZipCode { get; set; }

        [Column("ContactPhone")]
        public string PhoneNumber { get; set; }

        [Column("ContactMobile")]
        public string MobileNumber { get; set; }

        [Column("ContactEmail")]
        public string Email { get; set; }
    }
}