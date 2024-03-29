﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting.DTO;

namespace LeagueSandbox.GameServer.Core.Scripting
{
    public interface IMapScript
    {
        MapType MapType { get; }
        MapInitializationData Initialize();
        MinionSpawnResult SpawnMinion(int minionNumber, IObjBarracksDampener barrack);
    }
}
