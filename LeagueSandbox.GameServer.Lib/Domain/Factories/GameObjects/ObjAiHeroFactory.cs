using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Config.Startup;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.Providers;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjAiHeroFactory : EntityFactoryBase<ObjAiHero>, IObjAiHeroFactory
    {
        private readonly IStatsFactory _statsFactory;
        private readonly INetworkIdCreationService _networkIdCreationService;
        private readonly ICharacterDataProvider _characterDataProvider;
        private readonly ISpellBookFactory _spellBookFactory;
        private readonly ISpellFactory _spellFactory;
        private readonly ISpellDataProvider _spellDataProvider;

        public ObjAiHeroFactory(IUnityContainer unityContainer, IStatsFactory statsFactory, INetworkIdCreationService networkIdCreationService, ICharacterDataProvider characterDataProvider, ISpellDataProvider spellDataProvider, ISpellBookFactory spellBookFactory, ISpellFactory spellFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
            _networkIdCreationService = networkIdCreationService;
            _characterDataProvider = characterDataProvider;
            _spellDataProvider = spellDataProvider;
            _spellBookFactory = spellBookFactory;
            _spellFactory = spellFactory;
        }

        public IObjAiHero CreateFromStartupPlayer(StartupPlayer player, int clientId)
        {
            var data = _characterDataProvider.ProvideCharacterData(player.Champion);
            var stats = _statsFactory.CreateFromCharacterData(data);
            var netId = _networkIdCreationService.GetNewNetId();
            var spellBook = _spellBookFactory.CreateFromCharacterData(player.Champion, data);

            var summonerSpell1Data = _spellDataProvider.ProvideSummonerSpellData(player.Summoner1);
            var summoner1 = _spellFactory.CreateSummonerSpell(SpellSlot.D, player.Summoner1, 1, summonerSpell1Data);
            spellBook.AddSpell(summoner1);
            stats.SetSpellEnabled(SpellSlot.D, true);

            var summonerSpell2Data = _spellDataProvider.ProvideSummonerSpellData(player.Summoner2);
            var summoner2 = _spellFactory.CreateSummonerSpell(SpellSlot.F, player.Summoner2, 1, summonerSpell2Data);
            spellBook.AddSpell(summoner2);
            stats.SetSpellEnabled(SpellSlot.F, true);

            //TODO: start location
            var instance = new ObjAiHero
            (
                player.Team,
                new Vector3(33, 0, 239),
                stats,
                netId, 
                player.Champion,
                player.Skin,
                spellBook,
                data.GameplayCollisionRadius,
                player.SummonerId,
                clientId,
                player.IsBot,
                false
            );

            return SetupDependencies(instance);
        }
    }
}
