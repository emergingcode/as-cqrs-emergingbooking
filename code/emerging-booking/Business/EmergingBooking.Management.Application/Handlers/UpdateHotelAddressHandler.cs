using System;
using System.Threading.Tasks;

using EmergingBooking.Infrastructure.Cqrs.Commands;
using EmergingBooking.Management.Application.Commands;
using EmergingBooking.Management.Application.Domain;
using EmergingBooking.Management.Application.Repository;

using MonoidSharp;

namespace EmergingBooking.Management.Application.Handlers
{
    internal class UpdateHotelAddressHandler : ICommandHandler<UpdateHotelAddress>
    {
        private readonly HotelPersistence _hotelPersistence;

        public UpdateHotelAddressHandler(HotelPersistence hotelPersistence)
        {
            _hotelPersistence = hotelPersistence;
        }

        public async Task<CommandResult> ExecuteAsync(UpdateHotelAddress command)
        {
            try
            {
                var hotel = await _hotelPersistence.RetrieveHotelByCodeAsync(command.HotelCode);

                if (hotel == null)
                    return CommandResult.Fail("There isn't an hotel to update the Address");

                var address = Address.Create(command.NewStreet,
                                             command.NewDistrict,
                                             command.NewCity,
                                             command.NewCountry,
                                             command.NewZipcode);

                var domainCombinedValues = Outcome.Combine(address);

                if (domainCombinedValues.Failure)
                {
                    return CommandResult.Fail(domainCombinedValues.ErrorMessages);
                }

                hotel.ChangeAddress(address.Value);

                await _hotelPersistence.UpdateHotelAddress(hotel);

                return CommandResult.Ok();
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error while updating the address for the hotel.");
            }
        }
    }
}