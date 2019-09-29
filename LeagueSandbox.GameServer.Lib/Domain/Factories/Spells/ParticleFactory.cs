using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Services;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal class ParticleFactory : EntityFactoryBase<Particle>, IParticleFactory
    {
        private readonly INetworkIdCreationService _networkIdCreationService;

        public ParticleFactory(IUnityContainer unityContainer, INetworkIdCreationService networkIdCreationService) : base(unityContainer)
        {
            _networkIdCreationService = networkIdCreationService;
        }

        public IParticle CreateFromSpellData(IObjAiHero source, IGameObject target, SpellData data)
        {
            var netId = _networkIdCreationService.GetNewNetId();
            var boneName = string.Empty;
            if (data.HaveHitBone)
                boneName = data.HitBoneName;

            var instance = new Particle(Team.Neutral, target.Position, 0, netId, source, target, data.AfterEffectName, boneName, 1);

            return SetupDependencies(instance);
        }
    }
}
