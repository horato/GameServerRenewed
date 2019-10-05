using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
   public class ShopData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Team Team { get; }

        public uint NetId { get; }

        public ShopData(Team team, uint netId)
        {
            Team = team;
            NetId = netId;
        }
    }
}
