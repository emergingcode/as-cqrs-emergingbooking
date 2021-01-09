using System;
using System.Collections.Generic;
using System.Linq;
using EmergingBooking.Infrastructure.Cqrs.Domain;
using EmergingBooking.Management.Application.Domain.Events;
using EmergingBooking.Reservation.Application.Domain.Events;

namespace EmergingBooking.Management.Application.Domain
{
    internal class Hotel : Aggregate
    {
        private IList<Room> _rooms;
        
        public Hotel(string name, int starsOfCategory, Address address,
            Contacts contacts, Guid code = default(Guid), Guid? identifier = null)
                : base(identifier)
        {
            Name = name;
            StarsOfCategory = starsOfCategory;
            StarsOfRating = 0;
            Address = address;
            Contacts = contacts;

            _rooms = new List<Room>();
            Rooms = new List<Room>();

            Code = code;

            if (Code == default(Guid))
            {
                Code = Guid.NewGuid();

                AddEvent(new HotelCreated(Code,
                    Name,
                    StarsOfCategory,
                    StarsOfRating,
                    Address,
                    Contacts));
            };
        }

        public Guid Code { get; }
        public string Name { get; }
        public int StarsOfCategory { get; }
        public int StarsOfRating { get; }
        public Address Address { get; private set; }
        public Contacts Contacts { get; private set; }

        public IEnumerable<Room> Rooms
        {
            get => _rooms.ToList();
            set => _rooms = value.ToList();
        }

        public void ChangeAddress(Address address)
        {
            Address = address;

            AddEvent(new HotelAddressUpdated(this.Code,
                                             address.Street,
                                             address.District,
                                             address.City,
                                             address.Country,
                                             address.ZipCode));
        }

        public void ChangeContacts(Contacts contacts)
        {
            Contacts = contacts;

            AddEvent(new HotelContactsUpdated(this.Code,
                                              contacts.Email,
                                              contacts.Phone,
                                              contacts.Mobile));
        }

        internal void AddRoom(Room room)
        {
            if (_rooms.Contains(room))
                throw new InvalidOperationException($"The room {room.Name} already was added.");

            _rooms.Add(room);

            AddEvent(new RoomAdded(room.Code,
                                   this.Code,
                                   room.Name,
                                   room.Description,
                                   room.PricePerNight,
                                   room.Capacity,
                                   room.AvailableQuantity,
                                   room.Amenities));
        }

        internal void RemoveRoom(Room room)
        {
            if (!_rooms.Contains(room))
                throw new InvalidOperationException($"The selected room {room.Name} doesn't exists to be removed.");

            _rooms.Remove(room);

            AddEvent(new RoomRemoved());
        }
    }
}