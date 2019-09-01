using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.Definitions
{
    public class MapPingRequest : RequestDefinition
    {
        public Vector2 Position { get;  }
        public uint TargetNetId { get;  }
        public PingCategory PingCategory { get;  }

        public MapPingRequest(Vector2 position, uint targetNetId, PingCategory pingCategory)
        {
            Position = position;
            TargetNetId = targetNetId;
            PingCategory = pingCategory;
        }
    }
}
