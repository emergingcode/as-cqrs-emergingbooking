using System;
using System.Collections.Generic;

using MonoidSharp;

using Newtonsoft.Json;

namespace EmergingBooking.Reservation.Application.Domain
{
    internal class BookedRoom
    {
        [JsonConstructor]
        private BookedRoom(Guid code, string description, int capacity, decimal pricePerNight)
        {
            Code = code;
            Description = description;
            Capacity = capacity;
            PricePerNight = pricePerNight;
        }

        public Guid Code { get; }
        public string Description { get; }
        public int Capacity { get; }
        public decimal PricePerNight { get; }

        public static Outcome<BookedRoom> Create(
            PossibleBe<Guid> code,
            PossibleBe<string> description,
            PossibleBe<int> capacity,
            PossibleBe<decimal> pricePerNight)
        {
            var roomValid = IsValidRoomToBook(code, description, capacity, pricePerNight);

            if (roomValid.Success)
            {
                return Outcome.Successfully(
                    new BookedRoom(
                        code.Value,
                        description.Value,
                        capacity.Value,
                        pricePerNight.Value));
            }

            return Outcome.Failed<BookedRoom>(roomValid.ErrorMessages);
        }

        private static Outcome<bool> IsValidRoomToBook(
            PossibleBe<Guid> code,
            PossibleBe<string> description,
            PossibleBe<int> capacity,
            PossibleBe<decimal> pricePerNight)
        {
            List<string> errors = new List<string>();

            if (code.HasNoValue)
                errors.Add($"The Room's {nameof(code)} MUST be filled");

            if (description.HasNoValue)
                errors.Add($"The Room's {nameof(description)} MUST be filled");

            if (capacity.HasNoValue)
                errors.Add($"The Room's {nameof(capacity)} MUST be greater than Zero");

            if (pricePerNight.HasNoValue)
                errors.Add($"The Room's {nameof(pricePerNight)} MUST be greater than Zero");

            return errors.Count == 0 ? Outcome.Successfully(true) : Outcome.Failed<bool>(errors);
        }
    }
}