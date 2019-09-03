using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeagueSandbox.GameServer.Core.RequestProcessing.DTOs
{
    public class CompressedWaypoint
    {
        public int Order { get; }
        public Vector2 Position { get; }

        public CompressedWaypoint(int order, Vector2 position)
        {
            Order = order;
            Position = position;
        }
    }
}
