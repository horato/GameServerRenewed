using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal class StatsFactory : EntityFactoryBase<Entities.Stats.Stats>, IStatsFactory
    {
        private readonly IStatFactory _statFactory;

        public StatsFactory(IUnityContainer unityContainer, IStatFactory statFactory) : base(unityContainer)
        {
            _statFactory = statFactory;
        }

        public IStats CreateDefaultStats()
        {
            var instance = new Entities.Stats.Stats
            (
                0,
                false,
                false,
                false,
                false,
                true,
                SpellFlags.TargetableToAll,
                ActionState.CanAttack | ActionState.CanCast | ActionState.CanMove | ActionState.Unknown,
                PrimaryAbilityResourceType.Mana,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                new float[64],
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(1.0f, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(2, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(1.0f, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                0,
                0,
                0,
                0,
                0,
                false,
                0
            );

            return SetupDependencies(instance);
        }
    }
}
