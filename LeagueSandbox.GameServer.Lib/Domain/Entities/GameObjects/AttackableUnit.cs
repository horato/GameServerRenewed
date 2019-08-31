﻿using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal abstract class AttackableUnit : GameObject, IAttackableUnit
    {
        public IStats Stats { get; }
        public uint NetId { get; }
        //TimeOfDeath

        protected AttackableUnit(Team team, Vector3 position, IStats stats, uint netId, float visionRadius) : base(team, position, visionRadius)
        {
            Stats = stats;
            NetId = netId;
        }
    }
}
