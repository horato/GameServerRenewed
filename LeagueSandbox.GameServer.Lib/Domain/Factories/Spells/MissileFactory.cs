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

        public IMissile CreateNew(IObjAiBase objAiBase, ISpellInstance spell, ISpellData spellData, bool isMissileDestroyedOnHit)
        {
            var start = objAiBase.Position;
            var destination = _calculationService.CalculateDestination(start.ToVector2(), spell.TargetPosition, spell.Definition.CastRange).ToVector3(start.Y);
            var direction = _calculationService.CalculateDirection(start, destination);
            var velocity = _calculationService.CalculateVelocity(start, destination, spellData.MissileSpeed);

            var instance = new Missile
            (
                objAiBase.Team,
                start,
                spellData.MissilePerceptionBubbleRadius,
                spell.FutureProjectileNetId,
                spellData.LineWidth,
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
                1f, // TODO: what is this
                isMissileDestroyedOnHit
            );

            return SetupDependencies(instance);
        }
    }
}