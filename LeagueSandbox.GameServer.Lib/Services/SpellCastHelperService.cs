using System;
using System.Linq;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.Services;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Stats;
using LeagueSandbox.GameServer.Lib.Maths;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class SpellCastHelperService : ISpellCastHelperService
    {
        private readonly ICalculationService _calculationService;
        private readonly IFlatStatModifierFactory _flatStatModifierFactory;
        private readonly ISpellInstanceFactory _spellInstanceFactory;
        private readonly IPlayerCache _playerCache;
        private readonly IPacketNotifier _packetNotifier;

        public SpellCastHelperService(ICalculationService calculationService, IFlatStatModifierFactory flatStatModifierFactory, ISpellInstanceFactory spellInstanceFactory, IPlayerCache playerCache, IPacketNotifier packetNotifier)
        {
            _calculationService = calculationService;
            _flatStatModifierFactory = flatStatModifierFactory;
            _spellInstanceFactory = spellInstanceFactory;
            _playerCache = playerCache;
            _packetNotifier = packetNotifier;
        }

        public void CastSpell(ISpell spell, IAttackableUnit targetUnit, IObjAiBase caster, Vector2 targetPosition, Vector2 targetPositionEnd, uint? projectileId = null)
        {
            // Spell cooldown
            if (spell.State != SpellState.Ready)
                return;

            if (spell.SpellData.TargetingType == TargetingType.Target)
            {
                if (targetUnit == null)
                    throw new InvalidOperationException("Missing target for targeted spell");

                // Cast range
                var distance = _calculationService.CalculateDistance(caster, targetUnit);
                if (distance > spell.CastRange)
                    return;
            }

            // Mana cost
            var manaCost = _calculationService.CalculateManaCost(spell, caster);
            if (manaCost > caster.Stats.FlatManaPoints.CurrentValue)
                return;

            // Consume mana
            var manaDiff = _calculationService.CalculateManaDifferenceAfterSpellCast(caster, manaCost);
            var modifier = _flatStatModifierFactory.CreateValueModifier(manaDiff);
            caster.Stats.FlatManaPoints.ApplyStatModifier(modifier);

            // Cast
            var spellInstance = _spellInstanceFactory.CreateNew(spell, targetPosition, targetPositionEnd, targetUnit, manaCost, projectileId);
            caster.SpellBook.BeginCasting(spellInstance);

            if (!ShouldNotifySpellCast(spellInstance.Definition.Slot))
                return;

            // Response
            var summonerIds = _playerCache.GetAllPlayers().Select(x => x.SummonerId);
            _packetNotifier.NotifyCastSpellAns(summonerIds, caster, spellInstance);
        }

        private bool ShouldNotifySpellCast(SpellSlot slot)
        {
            switch (slot)
            {
                case SpellSlot.Q:
                case SpellSlot.W:
                case SpellSlot.E:
                case SpellSlot.R:
                case SpellSlot.D:
                case SpellSlot.F:
                case SpellSlot.BaseAttack:
                case SpellSlot.ExtraAttack1:
                case SpellSlot.ExtraAttack2:
                case SpellSlot.ExtraAttack3:
                case SpellSlot.ExtraAttack4:
                case SpellSlot.ExtraAttack5:
                case SpellSlot.ExtraAttack6:
                case SpellSlot.ExtraAttack7:
                case SpellSlot.ExtraAttack8:
                case SpellSlot.CritAttack:
                case SpellSlot.ExtraCritAttack1:
                case SpellSlot.ExtraCritAttack2:
                case SpellSlot.ExtraCritAttack3:
                case SpellSlot.ExtraCritAttack4:
                case SpellSlot.ExtraCritAttack5:
                case SpellSlot.ExtraCritAttack6:
                case SpellSlot.ExtraCritAttack7:
                case SpellSlot.ExtraCritAttack8:
                    return true;
                case SpellSlot.ExtraSpell1:
                case SpellSlot.ExtraSpell2:
                case SpellSlot.ExtraSpell3:
                case SpellSlot.ExtraSpell4:
                case SpellSlot.ExtraSpell5:
                case SpellSlot.ExtraSpell6:
                case SpellSlot.ExtraSpell7:
                case SpellSlot.ExtraSpell8:
                case SpellSlot.ExtraSpell9:
                case SpellSlot.ExtraSpell10:
                case SpellSlot.ExtraSpell11:
                case SpellSlot.ExtraSpell12:
                case SpellSlot.ExtraSpell13:
                case SpellSlot.ExtraSpell14:
                case SpellSlot.ExtraSpell15:
                case SpellSlot.ExtraSpell16:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}