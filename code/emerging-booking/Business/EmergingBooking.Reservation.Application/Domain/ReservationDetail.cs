using System;
using System.Collections.Generic;
using System.Linq;

using EmergingBooking.Infrastructure.Cqrs.Domain;
using EmergingBooking.Reservation.Application.Domain.Events;

using static System.String;

namespace EmergingBooking.Reservation.Application.Domain
{
    internal class ReservationDetail : Aggregate
    {
        public ReservationDetail(BookedHotel bookedHotel, BookedRoom bookedRoom,
            Period bookingPeriod, string bookedBy, int numberOfGuests, bool breakfastIncluded)
                : base(Guid.NewGuid())
        {
            BookingPeriod = bookingPeriod;
            BookedBy = bookedBy;
            NumberOfGuests = numberOfGuests;
            BreakfastIncluded = breakfastIncluded;
            BookedHotel = bookedHotel;
            BookedRoom = bookedRoom;

            Code = GenerateReservationNumber();

            AddEvent(new ReservationCreated(Code,
                                            bookedBy,
                                            numberOfGuests,
                                            NumberOfNights,
                                            PaidPrice,
                                            breakfastIncluded,
                                            bookingPeriod,
                                            bookedHotel,
                                            bookedRoom));
        }

        public string BookedBy { get; }
        public int NumberOfGuests { get; }
        public int NumberOfNights => Period.EvaluateNumberOfNights(BookingPeriod);
        public decimal PaidPrice => NumberOfNights * BookedRoom.PricePerNight;
        public string Code { get; }
        public bool BreakfastIncluded { get; }
        public Period BookingPeriod { get; }
        public BookedHotel BookedHotel { get; }
        public BookedRoom BookedRoom { get; }

        private string GenerateReservationNumber()
        {
            long i = Guid.NewGuid()
                         .ToByteArray()
                         .Aggregate<byte, long>(1, (current, b) => current * (b + 1));

            return $"{i - BookingPeriod.Checkin.Ticks:x}";
        }
    }

    internal class BookedRoom
    {
        public BookedRoom(Guid code, string description, int capacity, decimal pricePerNight)
        {
            if (code == Guid.Empty)
                throw new InvalidOperationException($"The Room's {nameof(code)} MUST be filled");

            if (IsNullOrWhiteSpace(description))
                throw new InvalidOperationException($"The Room's {nameof(description)} MUST be filled");

            if (capacity <= 0)
                throw new InvalidOperationException($"The Room's {nameof(capacity)} MUST be greater than Zero");

            if (pricePerNight <= 0)
                throw new InvalidOperationException($"The Room's {nameof(pricePerNight)} MUST be greater than Zero");

            Code = code;
            Description = description;
            Capacity = capacity;
            PricePerNight = pricePerNight;
        }

        public Guid Code { get; }
        public string Description { get; }
        public int Capacity { get; }
        public decimal PricePerNight { get; }
    }

    internal class BookedHotel
    {
        public BookedHotel(string name, string address, int starsOfCategory)
        {
            if (IsNullOrWhiteSpace(name))
                throw new InvalidOperationException($"The Hotel {nameof(name)} MUST be filled");

            if (IsNullOrWhiteSpace(address))
                throw new InvalidOperationException($"The Hotel {nameof(address)} MUST be filled");

            if (starsOfCategory <= 0)
                throw new InvalidOperationException($"The Hotel {nameof(starsOfCategory)} MUST be greater than Zero");

            Name = name;
            Address = address;
            StarsOfCategory = starsOfCategory;
        }

        public string Name { get; }
        public string Address { get; }
        public int StarsOfCategory { get; }
    }

    internal class Period : ValueObject
    {
        private Period(DateTime checkin, DateTime checkout)
        {
            if (checkin == DateTime.MinValue)
                throw new InvalidOperationException($"The {nameof(checkin)} date MUST be filled");

            if (checkout == DateTime.MinValue)
                throw new InvalidOperationException($"The {nameof(checkout)} date MUST be filled");

            if (checkin > checkout)
                throw new InvalidOperationException($"The {nameof(checkin)} date MUST not be greater than {nameof(checkout)} date");

            Checkin = checkin;
            Checkout = checkout;
        }

        public static Period Create(DateTime checkin, DateTime checkout)
        {
            return new Period(checkin, checkout);
        }

        public DateTime Checkin { get; }
        public DateTime Checkout { get; }

        public static int EvaluateNumberOfNights(Period period)
        {
            return (period.Checkout - period.Checkin).Days;
        }

        protected override IEnumerable<object> GetEqualityProperties()
        {
            yield return Checkin;
            yield return Checkout;
        }

        public override string ToString()
        {
            return $"{Checkin} - {Checkout}";
        }
    }
}