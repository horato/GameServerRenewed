using System;
using System.Numerics;
using LeagueSandbox.GameServer.Lib.Maths.DTO;

namespace LeagueSandbox.GameServer.Lib.Maths
{
    internal class CalculationService : ICalculationService
    {
        public PositionCalculationResult CalculateNewPosition(Vector2 from, Vector2 to, float movementSpeed, float millisecondDiff)
        {
            var goingTo = to - from;
            var direction = Vector2.Normalize(goingTo);
            if (float.IsNaN(direction.X) || float.IsNaN(direction.Y))
                throw new InvalidOperationException($"Invalid vector {direction.X}:{direction.Y}");

            var deltaMovement = movementSpeed * 0.001f * millisecondDiff;
            var newX = from.X + (direction.X * deltaMovement);
            var newY = from.Y + (direction.Y * deltaMovement);

            var newPosition = new Vector2(newX, newY);
            var destinationReached = GetDistance(newPosition, to) < deltaMovement * 2;

            return new PositionCalculationResult(newPosition, destinationReached);
        }

        private float GetDistance(Vector2 from, Vector2 to)
        {
            return (float)Math.Sqrt(GetDistanceSqr(from, to));
        }

        private float GetDistanceSqr(Vector2 from, Vector2 to)
        {
            return (from.X - to.X) * (from.X - to.X) + (from.Y - to.Y) * (from.Y - to.Y);
        }
    }
}