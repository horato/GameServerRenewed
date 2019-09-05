﻿using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;

namespace LeagueSandbox.GameServer.Lib.Controllers
{
    internal interface IGameObjectController
    {
        void InitializePlayers(IEnumerable<StartupPlayer> players);
        void UpdateObjects(float millisecondsDiff);
    }
}