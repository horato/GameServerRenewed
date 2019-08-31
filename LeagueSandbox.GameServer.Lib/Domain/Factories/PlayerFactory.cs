using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories
{
    internal class PlayerFactory : EntityFactoryBase<Player>, IPlayerFactory
    {
        public PlayerFactory(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        public IPlayer CreateFromStartupPlayer(StartupPlayer player, IObjAiHero champion)
        {
            var instance = new Player
            (
                player.SummonerId,
                player.SummonerLevel,
                player.Rank,
                player.Name,
                player.BadgeAlly,
                player.BadgeEnemy,
                player.Icon,
                champion,
                player.Runes);

            return SetupDependencies(instance);
        }
    }
}
