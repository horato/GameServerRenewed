﻿using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Scripting.DTO;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.Providers;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjAiMinionFactory : EntityFactoryBase<ObjAiMinion>, IObjAiMinionFactory
    {
        private readonly ICharacterDataProvider _characterDataProvider;
        private readonly ISpellBookFactory _spellBookFactory;
        private readonly IStatsFactory _statsFactory;
        private readonly INetworkIdCreationService _networkIdCreationService;

        public ObjAiMinionFactory(IUnityContainer unityContainer, IStatsFactory statsFactory, ICharacterDataProvider characterDataProvider, INetworkIdCreationService networkIdCreationService, ISpellBookFactory spellBookFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
            _characterDataProvider = characterDataProvider;
            _networkIdCreationService = networkIdCreationService;
            _spellBookFactory = spellBookFactory;
        }

        public IObjAiMinion CreateFromMinionInfo(IObjBarracksDampener barrack, string name, MinionInfo info)
        {
            var charData = _characterDataProvider.ProvideCharacterData(name);
            var stats = _statsFactory.CreateFromCharacterData(charData);
            var spellBook = _spellBookFactory.CreateFromCharacterData(name, charData);

            //TODO: append minion info stats

            var instance = new ObjAiMinion
            (
                barrack.Team,
                barrack.SpawnPoint.ToVector3(0),
                stats,
                _networkIdCreationService.GetNewNetId(),
                name,
                0,
                spellBook,
                MinionActionState.Spawned,
                barrack.MinionWaypoints,
                true,
                charData
            );

            return SetupDependencies(instance);
        }

        public IObjAiMinion CreateFromCharacterData(ICharacterData data, Team team, Vector3 position, IDictionary<int, Vector2> waypoints, bool isLaneMinion)
        {
            var stats = _statsFactory.CreateFromCharacterData(data);
            var spellbook = _spellBookFactory.CreateFromCharacterData(data.Name, data);
            var minion = new ObjAiMinion
            (
                team,
                position,
                stats,
                _networkIdCreationService.GetNewNetId(),
                data.Name,
                0,
                spellbook,
                MinionActionState.Spawned,
                waypoints,
                isLaneMinion,
                data
            );

            return minion;
        }
    }
}
