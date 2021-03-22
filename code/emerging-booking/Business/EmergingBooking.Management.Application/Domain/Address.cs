using System;
using System.Collections.Generic;

using EmergingBooking.Infrastructure.Cqrs.Domain;

using MonoidSharp;

using Newtonsoft.Json;

namespace EmergingBooking.Management.Application.Domain
{
    internal class Address : ValueObject
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

        public static Outcome<Address> Create(
            PossibleBe<string> street,
            PossibleBe<string> district,
            PossibleBe<string> city,
            PossibleBe<string> country,
            PossibleBe<int> zipCode)
        {
            if (IsValidAddress(street, district, city, country, zipCode))
            {
                return Outcome.Successfully(
                    new Address(
                        street.Value,
                        district.Value,
                        city.Value,
                        country.Value,
                        zipCode.Value));
            }

            return Outcome.Failed<Address>("The Address is invalid. Please verify all address values!");
        }

        private static bool IsValidAddress(
            PossibleBe<string> street,
            PossibleBe<string> district,
            PossibleBe<string> city,
            PossibleBe<string> country,
            PossibleBe<int> zipCode)
        {
            return street.HasValue &&
                district.HasValue &&
                city.HasValue &&
                country.HasValue &&
                zipCode.HasValue;
        }

        protected override IEnumerable<object> GetEqualityProperties()
        {
            yield return Street;
            yield return District;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }

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