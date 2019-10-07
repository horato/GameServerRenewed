using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
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

        public IStats CreateFromCharacterData(CharacterData data)
        {
            var instance = new Entities.Stats.Stats
            (
                0,
                SpellFlags.TargetableToAll,
                ActionState.CanAttack | ActionState.CanCast | ActionState.CanMove | ActionState.Unknown,
                data.PARType,
                false,
                false,
                false,
                false,
                true,
                false,
                0,
                0,
                _flatStatFactory.CreateNew(data.AttackSpeed, data.AttackSpeedPerLevel, 0, 0),
                _flatStatFactory.CreateNew(data.BaseHP, data.HPPerLevel, data.BaseStaticHPRegen, data.HPRegenPerLevel),
                _flatStatFactory.CreateNew(data.BaseMP, data.MPPerLevel, data.BaseStaticMPRegen, data.MPRegenPerLevel),
                _flatStatFactory.CreateNew(data.BaseDamage, data.DamagePerLevel, 0, 0),
                _flatStatFactory.CreateNew(data.BaseAbilityPower, data.AbilityPowerIncPerLevel, 0, 0),
                _flatStatFactory.CreateNew(data.Armor, data.ArmorPerLevel, 0, 0),
                _flatStatFactory.CreateNew(data.SpellBlock, data.SpellBlockPerLevel, 0, 0),
                _flatStatFactory.CreateNew(data.BaseCritChance, data.CritPerLevel, 0, 0),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _flatStatFactory.CreateEmpty(),
                _statFactory.CreateNew(data.BaseAbilityPower, 0, 0, 0, 0),
                _statFactory.CreateNew(data.Armor, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(data.BaseDamage, 0, 0, 0, 0),
                _statFactory.CreateNew(1, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(data.BaseCritChance, 0, 0, 0, 0),
                _statFactory.CreateNew(data.CritDamageBonus, 0, 0, 0, 0),
                _statFactory.CreateNew(data.BaseHP, 0, 0, 0, 0),
                _statFactory.CreateNew(data.BaseStaticHPRegen, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(data.SpellBlock, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(data.BaseMP, 0, 0, 0, 0),
                _statFactory.CreateNew(data.BaseStaticMPRegen, 0, 0, 0, 0),
                _statFactory.CreateNew(data.MoveSpeed, 0, 0, 0, 0),
                _statFactory.CreateNew(data.AttackRange, 0, 0, 0, 0),
                _statFactory.CreateNew(1.0f, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty()
            );

            return SetupDependencies(instance);
        }

        public IStats CreateFromBarrackData(IBarracksData data)
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
                _flatStatFactory.CreateNew(0, 0, data.BaseStaticHPRegen, 0),
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
                _statFactory.CreateNew(data.Armor, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(1.0f, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(2.0f, 0, 0, 0, 0),
                _statFactory.CreateNew(data.MaxHP, 0, 0, 0, 0),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateEmpty(),
                _statFactory.CreateNew(data.MaxMP, 0, 0, 0, 0),
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
