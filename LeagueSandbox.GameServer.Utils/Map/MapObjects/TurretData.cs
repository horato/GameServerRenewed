using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public class TurretData
    {
        public string SkinName { get; }
        public string CharacterName { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Team Team { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TurretPosition Position { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Lane Lane { get; }

        public TurretData(string skinName, string characterName, Team team, TurretPosition position, Lane lane)
        {
            SkinName = skinName;
            CharacterName = characterName;
            Team = team;
            Position = position;
            Lane = lane;
        }
    }
}
