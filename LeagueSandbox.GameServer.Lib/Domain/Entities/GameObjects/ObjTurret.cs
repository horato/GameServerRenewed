﻿using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjTurret : ObjAnimatedBuilding, IObjTurret
    {
        //SwapModelOnDeathTime
        //RemoveDeathIconTime
        //TurretSpawned 
        //TurretDestroyed
        public ObjTurret(Team team, Vector3 position, IStats stats, uint netId) : base(team, position, stats, netId)
        {
        }
    }
}
