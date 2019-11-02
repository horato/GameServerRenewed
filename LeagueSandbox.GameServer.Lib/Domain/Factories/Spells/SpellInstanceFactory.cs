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

        public ISpellInstance CreateNew(ISpell spell, Vector2 targetPosition, Vector2 targetEndPosition, IAttackableUnit targetUnit, float actualManaCost, uint? projectileId = null)
        {
            var instance = new SpellInstance
            (
                spell,
                SpellInstanceState.PreparingToCast,
                spell.SpellData.SpellCastTime,
                0,
                targetPosition,
                targetEndPosition,
                targetUnit,
                spell.SpellData.CastType == CastType.Instant ? 0 : _networkIdCreationService.GetNewNetId(),
                projectileId ?? _networkIdCreationService.GetNewNetId(),
                actualManaCost
            );

            return SetupDependencies(instance);
        }
    }
}
