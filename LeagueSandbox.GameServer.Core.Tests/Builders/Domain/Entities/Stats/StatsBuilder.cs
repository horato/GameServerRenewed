using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain.Entities.Stats
{
    internal class StatsBuilder : EntityBuilderBase<Lib.Domain.Entities.Stats.Stats>
    {
        private SpellSlot _spellsEnabled = SpellSlot.Q | SpellSlot.W | SpellSlot.E | SpellSlot.R;
        private SpellFlags _isTargetableToTeam = SpellFlags.TargetableToAll;
        private ActionState _actionState = ActionState.CanAttack | ActionState.CanCast;
        private PrimaryAbilityResourceType _parType = PrimaryAbilityResourceType.Mana;
        private bool _isMagicImmune = true;
        private bool _isInvulnerable = true;
        private bool _isPhysicalImmune = true;
        private bool _isLifestealImmune = true;
        private bool _isTargetable = true;
        private bool _isGeneratingGold = true;
        private float _spellCostReduction = 5.5f;
        private float _goldTotal = 54514;
        private IFlatStat _flatAttackSpeed = new FlatStatBuilder().Build();
        private IFlatStat _flatHealthPoints = new FlatStatBuilder().Build();
        private IFlatStat _flatManaPoints = new FlatStatBuilder().Build();
        private IFlatStat _flatAttackDamange = new FlatStatBuilder().Build();
        private IFlatStat _flatSpellDamage = new FlatStatBuilder().Build();
        private IFlatStat _flatArmor = new FlatStatBuilder().Build();
        private IFlatStat _flatMagicResist = new FlatStatBuilder().Build();
        private IFlatStat _flatCritChance = new FlatStatBuilder().Build();
        private IFlatStat _gold = new FlatStatBuilder().Build();
        private IFlatStat _level = new FlatStatBuilder().Build();
        private IFlatStat _experience = new FlatStatBuilder().Build();
        private IStat _abilityPower = new StatBuilder().Build();
        private IStat _armor = new StatBuilder().Build();
        private IStat _armorPenetration = new StatBuilder().Build();
        private IStat _attackDamage = new StatBuilder().Build();
        private IStat _attackSpeedMultiplier = new StatBuilder().Build();
        private IStat _cooldownReduction = new StatBuilder().Build();
        private IStat _criticalChance = new StatBuilder().Build();
        private IStat _criticalDamage = new StatBuilder().Build();
        private IStat _healthPoints = new StatBuilder().Build();
        private IStat _healthRegeneration = new StatBuilder().Build();
        private IStat _lifeSteal = new StatBuilder().Build();
        private IStat _magicResist = new StatBuilder().Build();
        private IStat _magicPenetration = new StatBuilder().Build();
        private IStat _manaPoints = new StatBuilder().Build();
        private IStat _manaRegeneration = new StatBuilder().Build();
        private IStat _moveSpeed = new StatBuilder().Build();
        private IStat _range = new StatBuilder().Build();
        private IStat _size = new StatBuilder().Build();
        private IStat _spellVamp = new StatBuilder().Build();
        private IStat _tenacity = new StatBuilder().Build();

        public StatsBuilder WithSpellsEnabled(SpellSlot spellsEnabled)
        {
            _spellsEnabled = spellsEnabled;
            return this;
        }

        public StatsBuilder WithIsTargetableToTeam(SpellFlags isTargetableToTeam)
        {
            _isTargetableToTeam = isTargetableToTeam;
            return this;
        }

        public StatsBuilder WithActionState(ActionState actionState)
        {
            _actionState = actionState;
            return this;
        }

        public StatsBuilder WithParType(PrimaryAbilityResourceType parType)
        {
            _parType = parType;
            return this;
        }

        public StatsBuilder WithIsMagicImmune(bool isMagicImmune)
        {
            _isMagicImmune = isMagicImmune;
            return this;
        }

        public StatsBuilder WithIsInvulnerable(bool isInvulnerable)
        {
            _isInvulnerable = isInvulnerable;
            return this;
        }

        public StatsBuilder WithIsPhysicalImmune(bool isPhysicalImmune)
        {
            _isPhysicalImmune = isPhysicalImmune;
            return this;
        }

        public StatsBuilder WithIsLifestealImmune(bool isLifestealImmune)
        {
            _isLifestealImmune = isLifestealImmune;
            return this;
        }

        public StatsBuilder WithIsTargetable(bool isTargetable)
        {
            _isTargetable = isTargetable;
            return this;
        }

        public StatsBuilder WithIsGeneratingGold(bool isGeneratingGold)
        {
            _isGeneratingGold = isGeneratingGold;
            return this;
        }

        public StatsBuilder WithSpellCostReduction(float spellCostReduction)
        {
            _spellCostReduction = spellCostReduction;
            return this;
        }

        public StatsBuilder WithGoldTotal(float goldTotal)
        {
            _goldTotal = goldTotal;
            return this;
        }

        public StatsBuilder WithFlatAttackSpeed(IFlatStat flatAttackSpeed)
        {
            _flatAttackSpeed = flatAttackSpeed;
            return this;
        }

        public StatsBuilder WithFlatHealthPoints(IFlatStat flatHealthPoints)
        {
            _flatHealthPoints = flatHealthPoints;
            return this;
        }

        public StatsBuilder WithFlatManaPoints(IFlatStat flatManaPoints)
        {
            _flatManaPoints = flatManaPoints;
            return this;
        }

        public StatsBuilder WithFlatAttackDamange(IFlatStat flatAttackDamange)
        {
            _flatAttackDamange = flatAttackDamange;
            return this;
        }

        public StatsBuilder WithFlatSpellDamange(IFlatStat flatSpellDamage)
        {
            _flatSpellDamage = flatSpellDamage;
            return this;
        }

        public StatsBuilder WithFlatArmor(IFlatStat flatArmor)
        {
            _flatArmor = flatArmor;
            return this;
        }

        public StatsBuilder WithFlatMagicResist(IFlatStat flatMagicResist)
        {
            _flatMagicResist = flatMagicResist;
            return this;
        }

        public StatsBuilder WithFlatCritChance(IFlatStat flatCritChance)
        {
            _flatCritChance = flatCritChance;
            return this;
        }

        public StatsBuilder WithGold(IFlatStat gold)
        {
            _gold = gold;
            return this;
        }

        public StatsBuilder WithLevel(IFlatStat level)
        {
            _level = level;
            return this;
        }

        public StatsBuilder WithExperience(IFlatStat experience)
        {
            _experience = experience;
            return this;
        }

        public StatsBuilder WithAbilityPower(IStat abilityPower)
        {
            _abilityPower = abilityPower;
            return this;
        }

        public StatsBuilder WithArmor(IStat armor)
        {
            _armor = armor;
            return this;
        }

        public StatsBuilder WithArmorPenetration(IStat armorPenetration)
        {
            _armorPenetration = armorPenetration;
            return this;
        }

        public StatsBuilder WithAttackDamage(IStat attackDamage)
        {
            _attackDamage = attackDamage;
            return this;
        }

        public StatsBuilder WithAttackSpeedMultiplier(IStat attackSpeedMultiplier)
        {
            _attackSpeedMultiplier = attackSpeedMultiplier;
            return this;
        }

        public StatsBuilder WithCooldownReduction(IStat cooldownReduction)
        {
            _cooldownReduction = cooldownReduction;
            return this;
        }

        public StatsBuilder WithCriticalChance(IStat criticalChance)
        {
            _criticalChance = criticalChance;
            return this;
        }

        public StatsBuilder WithCriticalDamage(IStat criticalDamage)
        {
            _criticalDamage = criticalDamage;
            return this;
        }

        public StatsBuilder WithHealthPoints(IStat healthPoints)
        {
            _healthPoints = healthPoints;
            return this;
        }

        public StatsBuilder WithHealthRegeneration(IStat healthRegeneration)
        {
            _healthRegeneration = healthRegeneration;
            return this;
        }

        public StatsBuilder WithLifeSteal(IStat lifeSteal)
        {
            _lifeSteal = lifeSteal;
            return this;
        }

        public StatsBuilder WithMagicResist(IStat magicResist)
        {
            _magicResist = magicResist;
            return this;
        }

        public StatsBuilder WithMagicPenetration(IStat magicPenetration)
        {
            _magicPenetration = magicPenetration;
            return this;
        }

        public StatsBuilder WithManaPoints(IStat manaPoints)
        {
            _manaPoints = manaPoints;
            return this;
        }

        public StatsBuilder WithManaRegeneration(IStat manaRegeneration)
        {
            _manaRegeneration = manaRegeneration;
            return this;
        }

        public StatsBuilder WithMoveSpeed(IStat moveSpeed)
        {
            _moveSpeed = moveSpeed;
            return this;
        }

        public StatsBuilder WithRange(IStat range)
        {
            _range = range;
            return this;
        }

        public StatsBuilder WithSize(IStat size)
        {
            _size = size;
            return this;
        }

        public StatsBuilder WithSpellVamp(IStat spellVamp)
        {
            _spellVamp = spellVamp;
            return this;
        }

        public StatsBuilder WithTenacity(IStat tenacity)
        {
            _tenacity = tenacity;
            return this;
        }

        public override Lib.Domain.Entities.Stats.Stats Build()
        {
            var instance = new Lib.Domain.Entities.Stats.Stats(_spellsEnabled, _isTargetableToTeam, _actionState, _parType, _isMagicImmune, _isInvulnerable, _isPhysicalImmune, _isLifestealImmune, _isTargetable, _isGeneratingGold, _spellCostReduction, _goldTotal, _flatAttackSpeed, _flatHealthPoints, _flatManaPoints, _flatAttackDamange, _flatSpellDamage, _flatArmor, _flatMagicResist, _flatCritChance, _gold, _level, _experience, _abilityPower, _armor, _armorPenetration, _attackDamage, _attackSpeedMultiplier, _cooldownReduction, _criticalChance, _criticalDamage, _healthPoints, _healthRegeneration, _lifeSteal, _magicResist, _magicPenetration, _manaPoints, _manaRegeneration, _moveSpeed, _range, _size, _spellVamp, _tenacity);

            return instance;
        }
    }
}
