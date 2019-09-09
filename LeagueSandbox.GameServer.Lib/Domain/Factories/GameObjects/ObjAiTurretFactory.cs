using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Config.Startup;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.MapObjects;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjAiTurretFactory : EntityFactoryBase<ObjAiTurret>, IObjAiTurretFactory
    {
        private readonly IStatsFactory _statsFactory;
        private readonly INetworkIdCreationService _networkIdCreationService;
        private readonly ICharacterDataProvider _characterDataProvider;

        public ObjAiTurretFactory(IUnityContainer unityContainer, IStatsFactory statsFactory, INetworkIdCreationService networkIdCreationService, ICharacterDataProvider characterDataProvider) : base(unityContainer)
        {
            _statsFactory = statsFactory;
            _networkIdCreationService = networkIdCreationService;
            _characterDataProvider = characterDataProvider;
        }

        public IObjAiTurret CreateFromMapObject(MapObject obj)
        {
            var data = _characterDataProvider.ProvideCharacterData(obj.TurretData.CharacterName);
            var stats = _statsFactory.CreateFromCharacterData(data);
            
            stats.UpdateTargetability(true, SpellFlags.NonTargetableEnemy);

            var instance = new ObjAiTurret
            (
                obj.TurretData.Team,
                obj.Position,
                stats,
                _networkIdCreationService.GetNewNetId(),
                obj.TurretData.SkinName,
                obj.SkinId,
                obj.TurretData.Lane,
                obj.TurretData.Position
            );

            return SetupDependencies(instance);
        }
    }
}
