using EmergingBooking.Message.Consumer.Models;
using EmergingBooking.Message.Consumer.Models.Events;

namespace EmergingBooking.Message.Consumer.Extensions
{
    internal static class ReservationMessageExtension
    {
        internal static ReservationData ParserTo(this ReservationCreatedMessage roomMessage)
        {
            return new ReservationData
            {
                Code = roomMessage.Code,
                BookedBy = roomMessage.BookedBy,
                BreakfastIncluded = roomMessage.BreakfastIncluded,
                Checkin = roomMessage.Checkin,
                Checkout = roomMessage.Checkout,
                HotelAddress = roomMessage.HotelAddress,
                HotelName = roomMessage.HotelName,
                HotelStarsOfCategory = roomMessage.HotelStarsOfCategory,
                NumberOfGuests = roomMessage.NumberOfGuests,
                NumberOfNights = roomMessage.NumberOfNights,
                PaidPrice = roomMessage.PaidPrice,
                PricePerNight = roomMessage.PricePerNight,
                RoomCode = roomMessage.RoomCode,
                RoomCapacity = roomMessage.RoomCapacity,
                RoomDescription = roomMessage.RoomDescription
            };
        }
    }
}