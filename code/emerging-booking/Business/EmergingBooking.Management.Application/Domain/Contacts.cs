using System.Collections.Generic;

using EmergingBooking.Infrastructure.Cqrs.Domain;

using MonoidSharp;

using Newtonsoft.Json;

namespace EmergingBooking.Management.Application.Domain
{
    internal class Contacts : ValueObject
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

        public static Outcome<Contacts> Create(
            PossibleBe<string> phone,
            PossibleBe<string> mobile,
            PossibleBe<string> email)
        {
            if (AreContactsValid(phone, mobile, email))
            {
                return Outcome.Successfully(
                    new Contacts(
                        phone.Value,
                        mobile.Value,
                        email.Value));
            }

            return Outcome.Failed<Contacts>("All contacts are invalid. Please verify all contact values!");
        }

        private static bool AreContactsValid(
            PossibleBe<string> phone,
            PossibleBe<string> mobile,
            PossibleBe<string> email)
        {
            return phone.HasValue && mobile.HasValue && email.HasValue;
        }

        protected override IEnumerable<object> GetEqualityProperties()
        {
            yield return Mobile;
            yield return Phone;
            yield return Email;
        }
    }
}