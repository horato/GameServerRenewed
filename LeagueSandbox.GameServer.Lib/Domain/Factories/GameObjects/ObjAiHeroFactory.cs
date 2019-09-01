using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjAiHeroFactory : EntityFactoryBase<ObjAiHero>, IObjAiHeroFactory
    {
        private readonly IStatsFactory _statsFactory;
        private readonly INetworkIdCreationService _networkIdCreationService;

        public ObjAiHeroFactory(IUnityContainer unityContainer, IStatsFactory statsFactory, INetworkIdCreationService networkIdCreationService) : base(unityContainer)
        {
            _statsFactory = statsFactory;
            _networkIdCreationService = networkIdCreationService;
        }

        public IObjAiHero CreateFromStartupPlayer(StartupPlayer player, int clientId)
        {
            var stats = _statsFactory.CreateDefaultStats();
            var netId = _networkIdCreationService.GetNewNetId();
            //TODO: start location
            var instance = new ObjAiHero(player.Team, new Vector3(), stats, netId, player.SummonerId, clientId, player.IsBot, false, player.Champion, player.Skin, player.Summoner1, player.Summoner2);

            return SetupDependencies(instance);
        }
    }
}
