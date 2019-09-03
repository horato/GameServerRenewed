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

        public static Vector3 ToVector3(this Vector2 vector, float z)
        {
            return new Vector3(vector.X, vector.Y, z);
        }
    }
}
