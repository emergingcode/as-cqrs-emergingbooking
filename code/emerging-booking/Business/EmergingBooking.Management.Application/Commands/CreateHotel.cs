using EmergingBooking.Infrastructure.Cqrs.Commands;

namespace EmergingBooking.Management.Application.Commands
{
    public class CreateHotel : ICommand
    {
        public string Name { get; }
        public int StarsOfCategory { get; }
        public string Street { get; }
        public string District { get; }
        public string City { get; }
        public string Country { get; }
        public int Zipcode { get; }
        public string Email { get; }
        public string Phone { get; }
        public string Mobile { get; }

        public CreateHotel(string name, int starsOfCategory, string street,
            string district, string city, string country, int zipcode,
            string email, string phone, string mobile)
        {
            Name = name;
            StarsOfCategory = starsOfCategory;
            Street = street;
            District = district;
            City = city;
            Country = country;
            Zipcode = zipcode;
            Email = email;
            Phone = phone;
            Mobile = mobile;
        }
    }
}