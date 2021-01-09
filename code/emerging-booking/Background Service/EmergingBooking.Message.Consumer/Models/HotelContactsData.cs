using System;

using Dapper;

namespace EmergingBooking.Message.Consumer.Models
{
    [Table("Hotels")]
    public class HotelContactsData
    {
        [Key]
        [Column("Code")]
        public Guid HotelCode { get; set; }

        [Column("ContactEmail")]
        public string Email { get; set; }

        [Column("ContactPhone")]
        public string Phone { get; set; }

        [Column("ContactMobile")]
        public string Mobile { get; set; }
    }
}