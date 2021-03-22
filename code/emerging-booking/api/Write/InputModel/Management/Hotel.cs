using System.ComponentModel.DataAnnotations;

namespace EmergingBookingApi.InputModel.Management
{
    public class Hotel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int StarsOfCategory { get; set; }

        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [StringLength(100)]
        public string District { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        [StringLength(100)]
        public string Country { get; set; }

        [Required]
        public int Zipcode { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Phone]
        public string Mobile { get; set; }
    }
}