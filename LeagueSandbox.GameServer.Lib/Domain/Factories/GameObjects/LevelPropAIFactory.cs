using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class LevelPropAIFactory : EntityFactoryBase<LevelPropAI>, ILevelPropAIFactory
    {
        private readonly IStatsFactory _statsFactory;
        private readonly INetworkIdCreationService _networkIdCreationService;
        private readonly ISpellBookFactory _spellBookFactory;

        public LevelPropAIFactory(IUnityContainer unityContainer, IStatsFactory statsFactory, INetworkIdCreationService networkIdCreationService, ISpellBookFactory spellBookFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
            _networkIdCreationService = networkIdCreationService;
            _spellBookFactory = spellBookFactory;
        }

        public ILevelPropAI CreateFromMapObject(MapObject obj)
        {
            var stats = _statsFactory.CreateDefaultStats();
            var instance = new LevelPropAI
            (
                Team.Neutral,
                obj.Position,
                stats,
                _networkIdCreationService.GetNewNetId(), 
                obj.LevelPropData.SkinName,
                obj.SkinId,
                1200,
                _spellBookFactory.CreateEmpty(),
                0,
                obj.Rotation, 
                new Vector3(0, 0, 0), 
                obj.Scale,
                obj.LevelPropData.Name
            );

            return SetupDependencies(instance);
        }
    }
}
