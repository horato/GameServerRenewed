using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public class NavPointData : INavPointData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Lane Lane { get; }

        public int Order { get; }

        public NavPointData(Lane lane, int order)
        {
            Lane = lane;
            Order = order;
        }
    }
}
