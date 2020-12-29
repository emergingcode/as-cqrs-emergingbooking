using System;
using System.Collections.Generic;
using System.Linq;

namespace EmergingBooking.Management.Application.Domain
{
    internal class Room
    {
        private readonly IList<string> _amenities;

        public Room(string name, string description, int capacity,
            int availableQuantity, decimal pricePerNight, Guid? code = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new InvalidOperationException($"The room's {nameof(name)} MUST be filled");

            Code = code ?? Guid.NewGuid();

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

        public void AddAmenities(string amenity)
        {
            if (_amenities.Contains(amenity))
                throw new InvalidOperationException($"The amenity {amenity} was already added.");

            _amenities.Add(amenity);
        }
    }
}