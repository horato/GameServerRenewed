using System.Numerics;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.Spells
{
    public interface IMissile : IGameObject
    {
        IObjAiBase Caster { get; }
        IAttackableUnit Target { get; }
        ISpellInstance Spell { get; }
        MissileState MissileState { get; }
        Vector3 Direction { get; }
        Vector3 Velocity { get; }
        Vector3 StartPoint { get; }
        Vector3 EndPoint { get; }
        float CreatedAtGameTimeMilliseconds { get; }
        float LifePercentage { get; }
        float TimedSpeedDelta { get; }
        float TimedSpeedDeltaTime { get; }
        bool DestroyOnHit { get; }
        ISpellData SpellData { get; }

        float GetMissileSpeed();
        void Launched();
        void DestinationReached();
        void Terminated();
    }
}