using System;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Maths.DTO;
using Unity.Storage;

namespace LeagueSandbox.GameServer.Lib.Maths
{
    internal class CalculationService : ICalculationService
    {
        public PositionCalculationResult CalculateNewPosition(Vector2 from, Vector2 to, float movementSpeed, float millisecondDiff)
        {
            var direction = CalculateDirection(from, to);
            if (float.IsNaN(direction.X) || float.IsNaN(direction.Y))
                throw new InvalidOperationException($"Invalid vector {direction.X}:{direction.Y}");

            var deltaMovement = movementSpeed * 0.001f * millisecondDiff;
            var newX = from.X + (direction.X * deltaMovement);
            var newY = from.Y + (direction.Y * deltaMovement);

            var newPosition = new Vector2(newX, newY);
            var destinationReached = GetDistance(newPosition, to) < deltaMovement * 2;

            return new PositionCalculationResult(newPosition, destinationReached);
        }

        public float CalculateManaCost(ISpell spell, IAttackableUnit unit)
        {
            return spell.ManaCost * (1 - unit.Stats.SpellCostReduction);
        }

        public float CalculateManaDifferenceAfterSpellCast(IAttackableUnit unit, float manaCost)
        {
            var stats = unit.Stats;
            var currentMana = stats.FlatManaPoints.CurrentValue;
            var newMana = currentMana - manaCost;
            return CalculateStatDifference(currentMana, newMana, stats.ManaPoints.Total, 0);
        }

        public float CalculateDistance(IGameObject from, IGameObject to)
        {
            return GetDistance(from.Position.ToVector2(), to.Position.ToVector2());
        }

        public Vector2 CalculateDirection(Vector2 start, Vector2 destination)
        {
            var direction = destination - start;
            return Vector2.Normalize(direction);
        }

        public Vector3 CalculateDirection(Vector3 start, Vector3 destination)
        {
            var direction = destination - start;
            return Vector3.Normalize(direction);
        }

        public Vector3 CalculateVelocity(Vector3 previousLocation, Vector3 currentLocation, float timeDelta)
        {
            return (currentLocation - previousLocation) / timeDelta;
        }

        public bool CalculateCollision(IGameObject obj1, IGameObject obj2)
        {
            var position1 = obj1.Position.ToVector2();
            var position2 = obj2.Position.ToVector2();
            return GetDistanceSqr(position1, position2) < (obj1.CollisionRadius + obj2.CollisionRadius) * (obj1.CollisionRadius + obj2.CollisionRadius);
        }

        public Vector2 CalculateDestination(Vector2 from, Vector2 to, float distance)
        {
            var direction = CalculateDirection(from, to);
            return from + (direction * distance);
        }

        public float CalculateStatDifference(float currentValue, float newValue, float maxValue, float minValue)
        {
            var tempValue = newValue;
            if (tempValue > maxValue)
                tempValue = maxValue;
            else if (tempValue < minValue)
                tempValue = minValue;

            return tempValue - currentValue;
        }

        public float CalculateStatDifferenceForLevelUp(float baseValue, float bonusPerLevel, float levelDifference)
        {
            var newValue = baseValue + (bonusPerLevel * levelDifference);
            return CalculateStatDifference(baseValue, newValue, float.MaxValue, float.MinValue);
        }

        public float CalculateStatDifferenceSubstract(float currentValue, float delta, float max, float min = 0)
        {
            var newValue = currentValue - delta;
            return CalculateStatDifference(currentValue, newValue, max, 0);
        }

        public float CalculateStatDifferenceAdd(float currentValue, float delta, float max, float min = 0)
        {
            return CalculateStatDifferenceSubstract(currentValue, -delta, max, min);
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