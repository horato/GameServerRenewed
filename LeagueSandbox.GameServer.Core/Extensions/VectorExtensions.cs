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
            return new Vector2(vector.X, vector.Z);
        }

        public static Vector3 ToVector3(this Vector2 vector, float y)
        {
            return new Vector3(vector.X, y, vector.Y);
        }
    }
}
