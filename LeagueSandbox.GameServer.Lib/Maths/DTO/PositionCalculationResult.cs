using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeagueSandbox.GameServer.Lib.Maths.DTO
{
    public class PositionCalculationResult
    {
        public Vector2 Result { get; }
        public bool IsDestinationReached { get; }

        public PositionCalculationResult(Vector2 result, bool isDestinationReached)
        {
            Result = result;
            IsDestinationReached = isDestinationReached;
        }
    }
}
