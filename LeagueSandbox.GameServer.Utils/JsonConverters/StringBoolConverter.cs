using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LeagueSandbox.GameServer.Utils.JsonConverters
{
    internal class StringBoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((bool)value ? "Yes" : "No");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value?.ToString() == "Yes";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}
