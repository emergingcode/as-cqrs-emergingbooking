using EmergingBooking.Management.Application.Domain.Events;

namespace EmergingBooking.Reservation.Application.Domain.Events
{
    internal sealed class RoomRemoved : HotelEventBaseV1
    {
        public RoomRemoved()
            : base(nameof(RoomRemoved))
        {
        }
    }
}