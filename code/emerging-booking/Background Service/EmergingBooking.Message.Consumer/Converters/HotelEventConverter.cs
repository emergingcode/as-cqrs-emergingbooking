using System;

using EmergingBooking.Infrastructure.KafkaConsumer;
using EmergingBooking.Message.Consumer.Constants;
using EmergingBooking.Message.Consumer.Models.Events;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmergingBooking.Message.Consumer.Converters
{
    public class HotelEventConverter : JsonCreationConverter<InternalEventBase>
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected override InternalEventBase Create(Type objectType, JObject jObject)
        {
            switch (jObject["EventName"].ToString())
            {
                case HotelEventNames.HotelCreated:
                    return new HotelCreatedMessage();

                case HotelEventNames.HotelAddressUpdated:
                    return new HotelAddressChangedMessage();

                case HotelEventNames.HotelContactsUpdated:
                    return new HotelContactsChangedMessage();

                case HotelEventNames.RoomAdded:
                    return new RoomAddedMessage();

                default:
                    throw new ArgumentException(
                        message: "The event is not recognized as valid",
                        paramName: jObject["EventName"].ToString());
            }
        }
    }
}