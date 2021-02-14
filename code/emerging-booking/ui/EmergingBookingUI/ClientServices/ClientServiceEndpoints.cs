namespace EmergingBookingUI.ClientServices
{
    public static class ClientServiceEndpoints
    {
        public static class HotelEndpoints
        {
            public const string CurrentAddress = "api/hotel/{0}/address/current";
            public static string UpdateAddress = "api/hotel/{0}/address/update";

            public const string CurrentContacts = "api/hotel/{0}/contacts/current";
            public static string UpdateContacts = "api/hotel/{0}/contacts/update";

            public const string ListRegisteredHotels = "api/hotel";
            public const string Register = "api/hotel";

            public const string RegisterRoom = "api/hotel/{0}/room";
            public const string ListRegisteredRooms = "api/Hotel/{0}/rooms";

            public const string AvailableRooms = "api/hotel/available-rooms?checking={0}&checkout={1}";
        }

        public static class BookingEndpoints
        {
            public const string BookRoom = "api/Booking";
            public const string ReservationDetails = "api/Booking/{0}/detail";
        }
    }
}