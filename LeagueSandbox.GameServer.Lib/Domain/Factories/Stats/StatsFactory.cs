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
        private readonly IFlatStatFactory _flatStatFactory;

        public StatsFactory(IUnityContainer unityContainer, IStatFactory statFactory, IFlatStatFactory flatStatFactory) : base(unityContainer)
        {
            _statFactory = statFactory;
            _flatStatFactory = flatStatFactory;
        }

        public IStats CreateDefaultStats()
        {
            var instance = new Entities.Stats.Stats
            (
                0,
                SpellFlags.TargetableToAll,
                ActionState.CanAttack | ActionState.CanCast | ActionState.CanMove | ActionState.Unknown,
                PrimaryAbilityResourceType.Mana,
                false,
                false,
                false,
                false,
                true,
                false,
                0,
                0,
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(1.0f, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(2.0f, 0, 0, 0, 0),
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
                _statFactory.CreateEmpty()
            );

            return SetupDependencies(instance);
        }
    }
}
