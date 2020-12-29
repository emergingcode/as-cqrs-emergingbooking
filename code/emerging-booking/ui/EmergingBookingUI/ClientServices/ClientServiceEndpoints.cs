namespace EmergingBookingUI.ClientServices
{
    public static class ClientServiceEndpoints
    {
        public static class HotelEndpoints
        {
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