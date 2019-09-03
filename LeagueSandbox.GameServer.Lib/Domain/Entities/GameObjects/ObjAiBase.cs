using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
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

        //ExpGiveRadius
        //GoldGiveRadius
        //Spellbook
        //    SpellBuffs
        //DeathTimer
        //VisionRegion
        protected ObjAiBase(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId, float visionRadius) : base(team, position, stats, netId, visionRadius)
        {
            SkinName = skinName;
            SkinId = skinId;
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
            if (!IsMoving)
                throw new InvalidOperationException("Movement is already stopped");

            _waypoints = new List<Vector2>();
            MovementType = MovementType.Stop;
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
    }
}
