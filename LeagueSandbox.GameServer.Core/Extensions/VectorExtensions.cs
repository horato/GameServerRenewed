using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeagueSandbox.GameServer.Core.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.X, vector.Y);
        }
    }
}
