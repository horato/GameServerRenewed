using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiBase : IAttackableUnit
    {
        string SkinName { get; }
        int SkinId { get; }
        IEnumerable<Vector2> Waypoints { get; }
        bool IsMoving { get; }
        MovementType MovementType { get; }
        ISpellBook SpellBook { get; }
        bool IsAttacking { get; }
        IAttackableUnit AttackTarget { get; }
        AutoAttackState AutoAttackState { get; }
        float CurrentAutoAttackCooldown { get; }
        float CurrentAutoAttackDelay { get; }
        bool IsMelee { get; }
        float AutoAttackCastTime { get; }
        uint AutoAttackProjectileId { get; }

        void Move(IEnumerable<Vector2> waypoints, MovementType movementType);
        void StopMovement();
        void Attack(IAttackableUnit target, IEnumerable<Vector2> path, MovementType movementType);
        void StopAttack();
        void AttackDelayProgress(float millisecondsDiff);
        void AttackCooldownProgress(float millisecondsDiff);
        void Attacking(uint autoAttackProjectileId);
        void WindingUp();
        void AttackFinished();

        void DoEmote();
        void OnMovementPointReached(Vector2 point);
        bool CanCast();
    }
}