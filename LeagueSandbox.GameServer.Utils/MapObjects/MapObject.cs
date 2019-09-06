using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.MapObjects
{
    public class MapObject
    {
        [JsonProperty("Name")]
        public string Name { get; }

        [JsonProperty("Hash")]
        public uint Hash { get; }

        [JsonProperty("NetId")]
        public uint NetId { get; }

        [JsonProperty("Position")]
        public Vector3 Position { get; }

        [JsonProperty("Rotation")]
        public Vector3 Rotation { get; }

        [JsonProperty("Scale")]
        public Vector3 Scale { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("Team")]
        public Team Team { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("ObjectType")]
        public ObjectType ObjectType { get; }

        public MapObject(string name, uint hash, uint netId, Vector3 position, Vector3 rotation, Vector3 scale, Team team, ObjectType objectType)
        {
            Name = name;
            Hash = hash;
            NetId = netId;
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Team = team;
            ObjectType = objectType;
        }
    }
}
