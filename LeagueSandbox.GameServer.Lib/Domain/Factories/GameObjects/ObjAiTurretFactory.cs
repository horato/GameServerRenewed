using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Domain.Factories.GameObjects;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.Map.MapObjects;
using LeagueSandbox.GameServer.Utils.Providers;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.GameObjects
{
    internal class ObjAiTurretFactory : EntityFactoryBase<ObjAiTurret>, IObjAiTurretFactory
    {
        private readonly IStatsFactory _statsFactory;
        private readonly INetworkIdCreationService _networkIdCreationService;
        private readonly ICharacterDataProvider _characterDataProvider;
        private readonly ISpellBookFactory _spellBookFactory;

        public ObjAiTurretFactory(IUnityContainer unityContainer, IStatsFactory statsFactory, INetworkIdCreationService networkIdCreationService, ICharacterDataProvider characterDataProvider, ISpellBookFactory spellBookFactory) : base(unityContainer)
        {
            _statsFactory = statsFactory;
            _networkIdCreationService = networkIdCreationService;
            _characterDataProvider = characterDataProvider;
            _spellBookFactory = spellBookFactory;
        }

        public IObjAiTurret CreateFromMapObject(IMapObject obj)
        {
            var data = _characterDataProvider.ProvideCharacterData(obj.TurretData.CharacterName);
            var stats = _statsFactory.CreateFromCharacterData(data);
            var spellBook = _spellBookFactory.CreateFromCharacterData(obj.TurretData.CharacterName, data);

            //TODO: Move to controller
            stats.UpdateTargetability(true, SpellFlags.NonTargetableEnemy);

            var instance = new ObjAiTurret
            (
                obj.TurretData.Team,
                obj.Position,
                stats,
                _networkIdCreationService.GetNewNetId(),
                obj.TurretData.SkinName,
                obj.SkinId,
                spellBook,
                obj.TurretData.Lane,
                obj.TurretData.Position,
                data
            );

            return SetupDependencies(instance);
        }
    }
}
