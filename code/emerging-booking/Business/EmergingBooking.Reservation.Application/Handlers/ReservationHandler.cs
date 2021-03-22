using System;
using System.Linq;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Reservation.Application.Commands;
using EmergingBooking.Reservation.Application.Domain;
using EmergingBooking.Reservation.Application.Repository;

using MonoidSharp;

namespace EmergingBooking.Reservation.Application.Handlers
{
    internal class ReservationHandler :
        ICommandHandler<MakeRoomReservation>,
        ICommandHandler<CancelReservation>
    {
        private readonly ReservationPersistence _reservationPersistence;
        private readonly HotelPersistence _hotelPersistence;

        public ReservationHandler(
            ReservationPersistence reservationPersistence,
            HotelPersistence hotelPersistence)
        {
            _hotelPersistence = hotelPersistence;
            _reservationPersistence = reservationPersistence;
        }

        public async Task<CommandResult> ExecuteAsync(MakeRoomReservation command)
        {
            try
            {
                var bookingPeriod = Period.Create(command.CheckingDate, command.CheckoutDate);

                bool roomIsAvailable =
                    await _reservationPersistence.CheckAvailabilityRoomAsync(bookingPeriod.Value, command.RoomCode);

                if (!roomIsAvailable)
                    return CommandResult.Fail($"This room was booked for this same period: {bookingPeriod}");

                var hotelAndRoomDetail =
                    await _hotelPersistence.RetrieveHotelAndRoomByCodeAsync(command.HotelCode,
                                                                            command.RoomCode);

                var selectedRoom = hotelAndRoomDetail.Rooms
                                                     .Where(x => x.Code == command.RoomCode)
                                                     .FirstOrDefault();

                var bookedHotel = BookedHotel.Create(hotelAndRoomDetail.Name,
                                                  hotelAndRoomDetail.Address.ToString(),
                                                  hotelAndRoomDetail.StarsOfCategory);

                var bookedRoom = BookedRoom.Create(selectedRoom.Code,
                                                selectedRoom.Description,
                                                selectedRoom.Capacity,
                                                selectedRoom.PricePerNight);

                var domainCombinedValues = Outcome.Combine(bookedHotel, bookedRoom);

                if (domainCombinedValues.Failure)
                {
                    return CommandResult.Fail(domainCombinedValues.ErrorMessages);
                }

                var reservation = new ReservationDetail(bookedHotel.Value,
                                                        bookedRoom.Value,
                                                        bookingPeriod.Value,
                                                        command.Guest,
                                                        command.NumberOfGuests,
                                                        command.BreakfastIncluded);

                await _reservationPersistence.SaveReservationAsync(reservation);

                return CommandResult.Ok();
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error while reserving a room " + ex.Message);
            }
        }

        public async Task<CommandResult> ExecuteAsync(CancelReservation command)
        {
            await _reservationPersistence.CancelReservation(command.ReservationCode);

            return CommandResult.Ok();
        }
    }
}