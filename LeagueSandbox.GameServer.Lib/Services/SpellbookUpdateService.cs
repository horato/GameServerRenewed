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
            var newCooldownRemaining = spell.CooldownRemaining - (millisecondsDiff / 1000.0f);
            if (newCooldownRemaining > 0)
            {
                spell.UpdateCooldownRemaining(newCooldownRemaining);
            }
            else
            {
                spell.UpdateCooldownRemaining(0);
                spell.UpdateState(SpellState.Ready);
            }
        }

        private void UpdateSpellInstance(IObjAiBase obj, float millisecondsDiff)
        {
            var spell = obj.SpellBook.CurrentSpell;
            if (spell == null)
                return;

            switch (spell.State)
            {
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

        private void UpdateCastTime(IObjAiBase obj, ISpellInstance spell, float millisecondsDiff)
        {
            var newCastTime = spell.CastTimeRemaining - (millisecondsDiff / 1000.0f);
            if (newCastTime > 0)
            {
                spell.UpdateCastTimeRemaining(newCastTime);
            }
            else
            {
                spell.UpdateCastTimeRemaining(0);

                if (spell.Definition.ChannelDuration > 0)
                {
                    spell.UpdateState(SpellInstanceState.Channeling);
                    spell.UpdateChannelTimeRemaining(spell.Definition.ChannelDuration);
                }
                else
                {
                    FinishCasting(obj, spell);
                }
            }
        }

        private void UpdateChannelTime(IObjAiBase obj, ISpellInstance spell, float millisecondsDiff)
        {
            var newChannelDuration = spell.ChannelTimeRemaining - (millisecondsDiff / 1000.0f);
            if (newChannelDuration > 0)
                return;

            FinishCasting(obj, spell);
        }

        private void FinishCasting(IObjAiBase obj, ISpellInstance spell)
        {
            spell.UpdateState(SpellInstanceState.Finished);

            spell.Definition.UpdateState(SpellState.Cooldown);
            spell.Definition.UpdateCooldownRemaining(GetCooldown(spell));

            if (obj is IObjAiHero hero)
                _packetNotifier.NotifySetCooldown(hero.SummonerId, obj, spell);
        }

        private float GetCooldown(ISpellInstance spell)
        {
            //TODO: option to turn off cooldowns globally
            return spell.Definition.Cooldown;
        }
    }
}