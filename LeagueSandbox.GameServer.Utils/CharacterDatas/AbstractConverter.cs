using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public class AbstractConverter<TAbstract, TReal> : JsonConverter
        where TReal : TAbstract
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TReal>(reader);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(TAbstract);
        }
    }
}
