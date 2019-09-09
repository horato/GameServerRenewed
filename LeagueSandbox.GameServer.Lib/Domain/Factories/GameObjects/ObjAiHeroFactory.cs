using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Lib.Services;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjAiHeroFactory : EntityFactoryBase<ObjAiHero>, IObjAiHeroFactory
    {
        private readonly IStatsFactory _statsFactory;
        private readonly INetworkIdCreationService _networkIdCreationService;
        private readonly ICharacterDataProvider _characterDataProvider;

        public ObjAiHeroFactory(IUnityContainer unityContainer, IStatsFactory statsFactory, INetworkIdCreationService networkIdCreationService, ICharacterDataProvider characterDataProvider) : base(unityContainer)
        {
            _statsFactory = statsFactory;
            _networkIdCreationService = networkIdCreationService;
            _characterDataProvider = characterDataProvider;
        }

        public IObjAiHero CreateFromStartupPlayer(StartupPlayer player, int clientId)
        {
            var data = _characterDataProvider.ProvideCharacterData(player.Champion);
            var stats = _statsFactory.CreateFromCharacterData(data);
            var netId = _networkIdCreationService.GetNewNetId();
            //TODO: start location
            var instance = new ObjAiHero(player.Team, new Vector3(33, 0, 239), stats, netId, player.SummonerId, clientId, player.IsBot, false, player.Champion, player.Skin, player.Summoner1, player.Summoner2);

            return SetupDependencies(instance);
        }
    }
}
