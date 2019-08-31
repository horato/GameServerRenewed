﻿using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal abstract class ObjBuilding : AttackableUnit, IObjBuilding
    {
        //DeathTimer
        //    ?Mesh
        //HealthRegenEnabled
        protected ObjBuilding(Team team, Vector3 position, IStats stats, uint netId, float visionRadius) : base(team, position, stats, netId, visionRadius)
        {
        }
    }
}
