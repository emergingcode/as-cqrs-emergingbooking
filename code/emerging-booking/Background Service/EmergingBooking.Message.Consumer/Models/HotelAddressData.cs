using System;

using Dapper;

namespace EmergingBooking.Message.Consumer.Models
{
    [Table("Hotels")]
    public class HotelAddressData
    {
        [Key]
        [Column("Code")]
        public Guid HotelCode { get; set; }

        [Column("AddressStreet")]
        public string Street { get; set; }

        [Column("AddressDistrict")]
        public string District { get; set; }

        [Column("AddressCity")]
        public string City { get; set; }

        [Column("AddressCountry")]
        public string Country { get; set; }

        public int ZipCode { get; set; }
    }
}