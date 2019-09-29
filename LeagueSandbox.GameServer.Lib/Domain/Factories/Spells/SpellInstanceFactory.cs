using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Services;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal class SpellInstanceFactory : EntityFactoryBase<SpellInstance>, ISpellInstanceFactory
    {
        private readonly INetworkIdCreationService _networkIdCreationService;

        public SpellInstanceFactory(IUnityContainer unityContainer, INetworkIdCreationService networkIdCreationService) : base(unityContainer)
        {
            _networkIdCreationService = networkIdCreationService;
        }

        public ISpellInstance CreateNew(ISpell spell, Vector2 position, Vector2 endPosition, IAttackableUnit targetUnit)
        {
            var instance = new SpellInstance
            (
                spell,
                SpellInstanceState.PreparingToCast,
                spell.CastTime,
                0,
                position, 
                endPosition,
                targetUnit,
                _networkIdCreationService.GetNewNetId(),
                _networkIdCreationService.GetNewNetId()
            );

            return SetupDependencies(instance);
        }
    }
}
