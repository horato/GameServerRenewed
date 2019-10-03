using System;
using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Extensions;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Maths;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal class MissileFactory : EntityFactoryBase<Missile>, IMissileFactory
    {
        private readonly ICalculationService _calculationService;
        private readonly Lazy<IGame> _game;

        public MissileFactory(IUnityContainer unityContainer, ICalculationService calculationService, Lazy<IGame> game) : base(unityContainer)
        {
            _calculationService = calculationService;
            _game = game;
        }

        public IMissile CreateNew(IObjAiBase objAiBase, ISpellInstance spell, ISpellData spellData)
        {
            var start = objAiBase.Position;
            var destination = spell.TargetPosition.ToVector3(0);

            var direction = _calculationService.CalculateDirection(start, destination);
            var velocity = _calculationService.CalculateVelocity(start, destination, spellData.MissileSpeed);

            var instance = new Missile
            (
                objAiBase.Team,
                start,
                spellData.MissilePerceptionBubbleRadius,
                spell.FutureProjectileNetId,
                objAiBase,
                spell.Target,
                spell,
                MissileState.Created,
                direction,
                velocity,
                start,
                destination,
                _game.Value.GameTimeElapsedMilliseconds,
                spellData.MissileSpeed,
                1f, //TODO: ?
                1f, // TODO: what is this
                1f // TODO: what is this
            );

            return SetupDependencies(instance);
        }
    }
}