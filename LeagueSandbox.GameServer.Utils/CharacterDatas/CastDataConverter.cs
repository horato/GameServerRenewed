using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    internal class CastDataConverter : JsonConverter
    {
        private static readonly JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings { ContractResolver = new BaseSpecifiedConcreteClassConverter() };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            if (!obj.ContainsKey(nameof(ICastData.CastType)))
                throw new InvalidOperationException($"Invalid value. Expected {nameof(ICastData.CastType)}");

            var castType = (CastType)obj[nameof(ICastData.CastType)].Value<int>();
            var targetType = castType switch
            {
                CastType.Instant => typeof(CastData.Instant),
                CastType.Missile => typeof(CastData.Missile.Normal),
                CastType.ChainMissile => typeof(CastData.Missile.Chain),
                CastType.ArcMissile => typeof(CastData.Missile.Line),
                CastType.CircleMissile => typeof(CastData.Missile.Circle),
                CastType.ScriptedMissile => throw new InvalidOperationException("Scripted missiles are not supported"),
                _ => throw new ArgumentOutOfRangeException(nameof(castType), castType, null),
            };

            return JsonConvert.DeserializeObject(obj.ToString(), targetType, SpecifiedSubclassConversion);
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(ICastData).IsAssignableFrom(objectType);
        }

        private class BaseSpecifiedConcreteClassConverter : DefaultContractResolver
        {
            protected override JsonConverter ResolveContractConverter(Type objectType)
            {
                if (typeof(ICastData).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                    return null; // to avoid a stack overflow

                return base.ResolveContractConverter(objectType);
            }
        }
    }
}
