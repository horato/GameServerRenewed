using System;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Extensions;
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

        public float CalculateManaCost(ISpell spell, IObjAiHero champion)
        {
            return spell.ManaCost * (1 - champion.Stats.SpellCostReduction);
        }

        public float CalculateManaDifferenceAfterSpellCast(IObjAiHero champion, float manaCost)
        {
            var stats = champion.Stats;
            var newMana = stats.FlatManaPoints.CurrentValue - manaCost;
            if (newMana < 0)
                newMana = 0;
            else if (newMana > stats.ManaPoints.Total)
                newMana = stats.ManaPoints.Total;

            return newMana - stats.FlatManaPoints.CurrentValue;
        }

        public float CalculateDistance(IObjAiHero champion, IAttackableUnit targetUnit)
        {
            return GetDistance(champion.Position.ToVector2(), targetUnit.Position.ToVector2());
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