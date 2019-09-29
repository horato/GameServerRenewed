using System;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class SpellbookUpdateService : ISpellbookUpdateService
    {
        private readonly IPacketNotifier _packetNotifier;

        public SpellbookUpdateService(IPacketNotifier packetNotifier)
        {
            _packetNotifier = packetNotifier;
        }

        public void UpdateSpellbook(IObjAiBase obj, float millisecondsDiff)
        {
            UpdateSpells(obj, millisecondsDiff);
            UpdateSpellInstance(obj, millisecondsDiff);
        }

        private void UpdateSpells(IObjAiBase obj, float millisecondsDiff)
        {
            var spells = obj.SpellBook.GetAllSpells();
            foreach (var spell in spells)
            {
                switch (spell.State)
                {
                    case SpellState.Ready:
                        break;
                    case SpellState.Cooldown:
                        UpdateCooldown(spell, millisecondsDiff);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void UpdateCooldown(ISpell spell, float millisecondsDiff)
        {
            var secondsDiff = millisecondsDiff / 1000.0f;
            spell.CooldownProgress(secondsDiff);
            if (spell.CooldownRemaining > 0)
                return;

            spell.CooldownFinished();
        }

        private void UpdateSpellInstance(IObjAiBase obj, float millisecondsDiff)
        {
            var spell = obj.SpellBook.CurrentSpell;
            if (spell == null)
                return;

            switch (spell.State)
            {
                case SpellInstanceState.PreparingToCast:
                    PrepareToCast(obj, spell, millisecondsDiff);
                    break;
                case SpellInstanceState.Casting:
                    UpdateCastTime(obj, spell, millisecondsDiff);
                    break;
                case SpellInstanceState.Channeling:
                    UpdateChannelTime(obj, spell, millisecondsDiff);
                    break;
                case SpellInstanceState.Finished:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PrepareToCast(IObjAiBase obj, ISpellInstance spell, float millisecondsDiff)
        {
            if (obj.IsMoving)
                obj.StopMovement();

            spell.CastingStart();
        }

        private void UpdateCastTime(IObjAiBase obj, ISpellInstance spell, float millisecondsDiff)
        {
            var secondsDiff = millisecondsDiff / 1000.0f;
            spell.CastingProgress(secondsDiff);
            if (spell.CastTimeRemaining > 0 && !spell.Definition.HasFlag(SpellFlags.InstantCast))
                return;

            if (spell.Definition.ChannelDuration > 0)
            {
                spell.ChannelingStart();
            }
            else
            {
                FinishCasting(obj, spell);
            }
        }

        private void UpdateChannelTime(IObjAiBase obj, ISpellInstance spell, float millisecondsDiff)
        {
            var secondsDiff = (millisecondsDiff / 1000.0f);
            spell.ChannelingProgress(secondsDiff);
            if (spell.ChannelTimeRemaining > 0)
                return;

            FinishCasting(obj, spell);
        }

        private void FinishCasting(IObjAiBase obj, ISpellInstance spell)
        {
            spell.CastingFinished();
            obj.SpellBook.CastingFinished();
            spell.Definition.StartCooldown();

            //TODO: cdr?
            if (obj is IObjAiHero hero)
                _packetNotifier.NotifySetCooldown(hero.SummonerId, obj, spell);
        }
    }
}