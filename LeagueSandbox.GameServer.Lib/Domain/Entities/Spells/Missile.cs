using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
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
        public float Speed { get; }
        public float LifePercentage { get; }
        public float TimedSpeedDelta { get; }
        public float TimedSpeedDeltaTime { get; }
        public bool DestroyOnHit { get; }

        public Missile(Team team, Vector3 position, float visionRadius, uint netId, float collisionRadius, IObjAiBase caster, IAttackableUnit target, ISpellInstance spell, MissileState missileState, Vector3 direction, Vector3 velocity, Vector3 startPoint, Vector3 endPoint, float createdAtGameTime, float speed, float lifePercentage, float timedSpeedDelta, float timedSpeedDeltaTime, bool destroyOnHit) : base(team, position, visionRadius, collisionRadius, netId)
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
            Speed = speed;
            LifePercentage = lifePercentage;
            TimedSpeedDelta = timedSpeedDelta;
            TimedSpeedDeltaTime = timedSpeedDeltaTime;
            DestroyOnHit = destroyOnHit;
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
