using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public class BarrackSpawnData : IBarrackSpawnData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Lane Lane { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Team Team { get; }
        public int Order { get; }

        public BarrackSpawnData(Lane lane, Team team, int order)
        {
            Lane = lane;
            Team = team;
            Order = order;
        }
    }
}
