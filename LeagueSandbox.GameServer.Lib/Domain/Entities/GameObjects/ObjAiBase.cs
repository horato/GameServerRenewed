using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal abstract class ObjAiBase : AttackableUnit, IObjAiBase
    {
        private IList<Vector2> _waypoints = new List<Vector2>();

        public string SkinName { get; }
        public int SkinId { get; }
        public MovementType MovementType { get; private set; }
        public IEnumerable<Vector2> Waypoints => _waypoints;
        public bool IsMoving => MovementType == MovementType.Move || MovementType == MovementType.Attackmove;
        public bool IsAttacking => MovementType == MovementType.Attack;
        public ISpellBook SpellBook { get; }
        public IAttackableUnit AttackTarget { get; private set; }
        public AutoAttackState AutoAttackState { get; private set; }
        public float CurrentAutoAttackCooldown { get; private set; }
        public float CurrentAutoAttackDelay { get; private set; }
        public ICharacterData CharacterData { get; }
        public uint AutoAttackProjectileId { get; private set; }

        //ExpGiveRadius
        //GoldGiveRadius
        //    SpellBuffs
        //DeathTimer
        //VisionRegion
        protected ObjAiBase(Team team, Vector3 position, IStats stats, uint netId, float visionRadius, float collisionRadius, string skinName, int skinId, ISpellBook spellBook, ICharacterData characterData) : base(team, position, stats, netId, visionRadius, collisionRadius)
        {
            SkinName = skinName;
            SkinId = skinId;
            SpellBook = spellBook;
            CharacterData = characterData;
            MovementType = MovementType.Stop;
        }

        public void Move(IEnumerable<Vector2> waypoints, MovementType movementType)
        {
            if (waypoints == null)
                throw new ArgumentNullException(nameof(waypoints));

            var waypointList = waypoints.ToList();
            if (!waypointList.Any())
                throw new InvalidOperationException("Unable to move. No waypoints.");

            _waypoints = waypointList;
            MovementType = movementType;
        }

        public void StopMovement()
        {
            if (!IsMoving && !IsAttacking)
                throw new InvalidOperationException("Movement is already stopped");

            _waypoints = new List<Vector2>();
            MovementType = MovementType.Stop;
        }

        public void Attack(IAttackableUnit target, IEnumerable<Vector2> path, MovementType movementType)
        {
            if (movementType != MovementType.Attack)
                throw new InvalidOperationException("Invalid order type. Attack expected.");
            if (AttackTarget != null && AttackTarget == target && AutoAttackState != AutoAttackState.Finished)
                return;

            AttackTarget = target ?? throw new ArgumentNullException(nameof(target));
            AutoAttackState = AutoAttackState.Preparing;
            Move(path, movementType);
        }

        public void StopAttack()
        {
            if (!IsAttacking)
                throw new InvalidOperationException("Attack is already stopped");

            AttackTarget = null;
            AutoAttackState = AutoAttackState.Finished;

            if (IsMoving)
                StopMovement();
        }

        public void AttackDelayProgress(float millisecondsDiff)
        {
            if (CurrentAutoAttackDelay > millisecondsDiff)
                CurrentAutoAttackDelay -= millisecondsDiff;
            else if (CurrentAutoAttackDelay > 0)
                CurrentAutoAttackDelay = 0;
        }

        public void AttackCooldownProgress(float millisecondsDiff)
        {
            if (CurrentAutoAttackCooldown > millisecondsDiff)
                CurrentAutoAttackCooldown -= millisecondsDiff;
            else if (CurrentAutoAttackCooldown > 0)
                CurrentAutoAttackCooldown = 0;
        }

        public void Attacking(uint autoAttackProjectileId)
        {
            if (AutoAttackState != AutoAttackState.Preparing)
                throw new InvalidOperationException("Invalid attack state.");
            if(!CharacterData.AttacksData.ContainsKey(AttackSlot.BaseAttack))
                throw new InvalidOperationException("Data for BaseAttack slot are missing"); //TODO: validate this on data load?

            AutoAttackState = AutoAttackState.Attacking;
            CurrentAutoAttackDelay = CharacterData.AttacksData[AttackSlot.BaseAttack].CastDelay(Stats.AttackSpeedMultiplier.Total);
            CurrentAutoAttackCooldown = 0;
            AutoAttackProjectileId = autoAttackProjectileId;
        }

        public void WindingUp()
        {
            if (AutoAttackState != AutoAttackState.Attacking)
                throw new InvalidOperationException("Invalid attack state.");
            if (!CharacterData.AttacksData.ContainsKey(AttackSlot.BaseAttack))
                throw new InvalidOperationException("Data for BaseAttack slot are missing"); //TODO: validate this on data load?

            AutoAttackState = AutoAttackState.Windup;
            CurrentAutoAttackDelay = 0;
            CurrentAutoAttackCooldown = CharacterData.AttacksData[AttackSlot.BaseAttack].Delay(Stats.AttackSpeedMultiplier.Total);
            AutoAttackProjectileId = 0;
        }

        public void AttackFinished()
        {
            if (AutoAttackState != AutoAttackState.Windup)
                throw new InvalidOperationException("Invalid attack state.");

            AutoAttackState = AutoAttackState.Finished;
        }

        public void DoEmote()
        {
            //TODO: emote
        }

        public void OnMovementPointReached(Vector2 point)
        {
            _waypoints.Remove(point);

            if (!_waypoints.Any())
                StopMovement();
        }

        public bool CanCast()
        {
            return Stats.GetActionState(ActionState.CanCast)
                   && !Stats.GetActionState(ActionState.Taunted)
                   && !Stats.GetActionState(ActionState.Feared)
                   && !Stats.GetActionState(ActionState.IsFleeing)
                   && !Stats.GetActionState(ActionState.IsAsleep)
                   && !Stats.GetActionState(ActionState.Charmed)
                   && !SpellBook.IsCastingSpell();
        }
    }
}
