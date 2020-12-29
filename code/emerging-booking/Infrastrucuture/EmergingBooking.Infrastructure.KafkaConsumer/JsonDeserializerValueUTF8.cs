using System;
using System.Text;

using Confluent.Kafka;

using Newtonsoft.Json;

namespace EmergingBooking.Infrastructure.KafkaConsumer
{
    internal class JsonDeserializerKeyUTF8<TKeyType> : IDeserializer<TKeyType>
    {
        public readonly Encoding encoder;

        public JsonDeserializerKeyUTF8()
        {
            encoder = Encoding.UTF8;
        }

        public TKeyType Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonConvert.DeserializeObject<TKeyType>(encoder.GetString(data.ToArray()));
        }
    }

    internal class JsonDeserializerValueUTF8<TEntity> : IDeserializer<TEntity>
    {
        public readonly Encoding encoder;

        private readonly JsonCreationConverter<TEntity> CustomCreationConverter;

        public JsonDeserializerValueUTF8(JsonCreationConverter<TEntity> customCreationConverter)
        {
            encoder = Encoding.UTF8;
            this.CustomCreationConverter = customCreationConverter;
        }

        public TEntity Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonConvert.DeserializeObject<TEntity>(encoder.GetString(data.ToArray()), this.CustomCreationConverter);
        }
    }
}