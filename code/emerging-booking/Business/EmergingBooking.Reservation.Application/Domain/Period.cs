using System;
using System.Collections.Generic;

using EmergingBooking.Infrastructure.Cqrs.Domain;

using MonoidSharp;

using Newtonsoft.Json;

namespace EmergingBooking.Reservation.Application.Domain
{
    internal class Period : ValueObject
    {
        [JsonConstructor]
        private Period(DateTime checkin, DateTime checkout)
        {
            Checkin = checkin;
            Checkout = checkout;
        }

        public DateTime Checkin { get; }
        public DateTime Checkout { get; }

        public static Outcome<Period> Create(DateTime checkin, DateTime checkout)
        {
            var validPeriod = IsValidPeriod(checkin, checkout);

            if (validPeriod.Success)
            {
                return Outcome.Successfully(new Period(checkin, checkout));
            }

            return Outcome.Failed<Period>(validPeriod.ErrorMessages);
        }

        private static Outcome<bool> IsValidPeriod(
            PossibleBe<DateTime> checkin,
            PossibleBe<DateTime> checkout)
        {
            List<string> errors = new List<string>();

            if (checkin.HasNoValue || (checkin == DateTime.MinValue))
                errors.Add($"The {nameof(checkin)} date MUST be filled");

            if (checkout.HasNoValue || (checkout == DateTime.MinValue))
                errors.Add($"The {nameof(checkout)} date MUST be filled");

            if (checkin.Value > checkout.Value)
                errors.Add($"The {nameof(checkin)} date MUST not be greater than {nameof(checkout)} date");

            return errors.Count == 0 ? Outcome.Successfully(true) : Outcome.Failed<bool>(errors);
        }

        public static int NumberOfNights(Period period)
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