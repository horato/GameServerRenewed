using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Config.Startup;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal interface IPlayerFactory
    {
        IPlayer CreateFromStartupPlayer(StartupPlayer player, IObjAiHero champion);
    }
}