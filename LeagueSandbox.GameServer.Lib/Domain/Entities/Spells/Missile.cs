using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.Spells
{
    internal class Missile : GameObject, IMissile
    {
        public IObjAiBase Caster { get; }
        public IAttackableUnit Target { get; }
        public ISpellInstance Spell { get; }
        public MissileState MissileState { get; private set; }
        public Vector3 Direction { get; }
        public Vector3 Velocity { get; }
        public Vector3 StartPoint { get; }
        public Vector3 EndPoint { get; }
        public float CreatedAtGameTimeMilliseconds { get; }
        public float LifePercentage { get; }
        public float TimedSpeedDelta { get; }
        public float TimedSpeedDeltaTime { get; }
        public bool DestroyOnHit { get; }
        public ISpellData SpellData { get; }

        public Missile(Team team, Vector3 position, uint netId, IObjAiBase caster, IAttackableUnit target, ISpellInstance spell, MissileState missileState, Vector3 direction, Vector3 velocity, Vector3 startPoint, Vector3 endPoint, float createdAtGameTime, float lifePercentage, float timedSpeedDelta, float timedSpeedDeltaTime, bool destroyOnHit, ISpellData spellData) : base(team, position, GetVisionRadius(spellData), spellData.LineWidth, netId)
        {
            Caster = caster;
            Target = target;
            Spell = spell;
            MissileState = missileState;
            Direction = direction;
            Velocity = velocity;
            StartPoint = startPoint;
            EndPoint = endPoint;
            CreatedAtGameTimeMilliseconds = createdAtGameTime;
            LifePercentage = lifePercentage;
            TimedSpeedDelta = timedSpeedDelta;
            TimedSpeedDeltaTime = timedSpeedDeltaTime;
            DestroyOnHit = destroyOnHit;
            SpellData = spellData;
        }

        private static float GetVisionRadius(ISpellData spellData)
        {
            return GetMissileCastData(spellData).PerceptionBubbleRadius;
        }

        public float GetMissileSpeed()
        {
            return GetMissileCastData(SpellData).Speed;
        }

        private static ICastDataMissile GetMissileCastData(ISpellData spellData)
        {
            switch (spellData.CastType)
            {
                case CastType.Instant:
                    throw new InvalidOperationException($"Expected missile cast type. Actual: {spellData.CastType}");
                case CastType.Missile:
                case CastType.ChainMissile:
                case CastType.ArcMissile:
                case CastType.CircleMissile:
                case CastType.ScriptedMissile:
                    return (ICastDataMissile)spellData.CastData;
                default:
                    throw new ArgumentOutOfRangeException(nameof(spellData.CastType), spellData.CastType, null);
            }
        }

        public void Launched()
        {
            if (MissileState != MissileState.Created)
                throw new InvalidOperationException("Failed to advance missile state. Invalid state.");

            MissileState = MissileState.Traveling;
        }

        public void DestinationReached()
        {
            if (MissileState != MissileState.Traveling)
                throw new InvalidOperationException("Failed to advance missile state. Invalid state.");

            MissileState = MissileState.Arrived;
        }

        public void Terminated()
        {
            if (MissileState != MissileState.Traveling)
                throw new InvalidOperationException("Failed to advance missile state. Invalid state.");

            MissileState = MissileState.Terminated;
        }
    }
}
