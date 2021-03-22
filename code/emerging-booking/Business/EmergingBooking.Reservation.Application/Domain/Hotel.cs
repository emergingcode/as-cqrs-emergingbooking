using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using static System.String;

namespace EmergingBooking.Reservation.Application.Domain
{
    internal class Hotel
    {
        private IList<Room> _rooms;

        public Hotel(string name, int starsOfCategory, Address address, Contacts contacts)
        {
            Name = name;
            StarsOfCategory = starsOfCategory;
            Address = address;
            Contacts = contacts;

            _rooms = new List<Room>();
            Rooms = new List<Room>();
        }

        public Guid Code { get; }
        public string Name { get; }

        public int StarsOfCategory { get; }

        public Address Address { get; }

        public Contacts Contacts { get; }

        public IEnumerable<Room> Rooms
        {
            get => _rooms.ToList();
            set => _rooms = value.ToList();
        }
    }

    internal class Room
    {
        private readonly IList<string> _amenities;

        public Room(string name, string description, int capacity,
            int availableQuantity, decimal pricePerNight, Guid code)
        {
            if (IsNullOrWhiteSpace(name))
                throw new InvalidOperationException($"The room's {nameof(name)} MUST be filled");

            Code = code;

            Name = name;
            Description = description;
            Capacity = capacity;
            AvailableQuantity = availableQuantity;
            PricePerNight = pricePerNight;

            _amenities = new List<string>();
        }

        public Guid Code { get; }
        public string Name { get; }
        public string Description { get; }
        public int Capacity { get; }
        public int AvailableQuantity { get; }
        public decimal PricePerNight { get; }
        public IReadOnlyList<string> Amenities => _amenities.ToList();
    }

    internal class Contacts
    {
        [JsonConstructor]
        private Contacts(string phone, string mobile, string email)
        {
            Phone = phone;
            Mobile = mobile;
            Email = email;
        }

        public string Mobile { get; }
        public string Phone { get; }
        public string Email { get; }
    }

    internal class Address
    {
        [JsonConstructor]
        private Address(string street, string district, string city, string country, int zipCode)
        {
            Street = street;
            District = district;
            City = city;
            Country = country;
            ZipCode = zipCode;
        }

        public string Street { get; }
        public string District { get; }
        public string City { get; }
        public string Country { get; }
        public int ZipCode { get; }

        public override string ToString()
        {
            return $"{Street}{Environment.NewLine}," +
                   $"{District}{Environment.NewLine}," +
                   $"{City}{Environment.NewLine}," +
                   $"{Country}{Environment.NewLine}," +
                   $"{ZipCode}";
        }
    }
}