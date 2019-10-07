using System;
using System.Linq;
using LeagueSandbox.GameServer.Core.Caches;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.RequestProcessing;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Caches;
using LeagueSandbox.GameServer.Lib.Domain.Factories.Spells;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.Services
{
    internal class SpellbookUpdateService : ISpellbookUpdateService
    {
        private readonly IPacketNotifier _packetNotifier;
        private readonly IMissileFactory _missileFactory;
        private readonly IGameObjectsCache _gameObjectsCache;
        private readonly ISpellScriptProvider _spellScriptProvider;
        private readonly ISpellDataProvider _spellDataProvider;

        public SpellbookUpdateService(IPacketNotifier packetNotifier, IMissileFactory missileFactory, IGameObjectsCache gameObjectsCache, ISpellScriptProvider spellScriptProvider, ISpellDataProvider spellDataProvider)
        {
            _packetNotifier = packetNotifier;
            _missileFactory = missileFactory;
            _gameObjectsCache = gameObjectsCache;
            _spellScriptProvider = spellScriptProvider;
            _spellDataProvider = spellDataProvider;
        }

        public void UpdateSpellbook(IObjAiBase obj, float millisecondsDiff)
        {
            UpdateSpells(obj, millisecondsDiff);
            //TODO: Move to spell instance update service?
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
            if (obj is IObjAiHero hero && spell.Definition.CooldownRemaining > 0)
                _packetNotifier.NotifySetCooldown(hero.SummonerId, obj, spell);

            var spellData = _spellDataProvider.ProvideCharacterSpellData(obj.SkinName, spell.Definition.SpellName);
            switch (spell.Definition.CastType)
            {
                case CastType.Instant:
                    // wrapper or an actual no missile spell
                    // nothing to do here yet
                    break;
                case CastType.Missile:
                case CastType.ChainMissile:
                case CastType.ArcMissile:
                case CastType.CircleMissile:
                case CastType.ScriptedMissile:
                    CreateMissile(obj, spell, spellData);

                    if (!_spellScriptProvider.SpellScriptExists(obj.SkinName, spell.Definition.SpellName))
                        return;

                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            var script = _spellScriptProvider.ProvideSpellScript(obj.SkinName, spell.Definition.SpellName);
            script.OnCastFinished(obj, spell, spellData);
        }

        private void CreateMissile(IObjAiBase obj, ISpellInstance spell, ISpellData spellData)
        {
            var missile = _missileFactory.CreateNew(obj, spell, spellData);
            _gameObjectsCache.Add(missile.NetId, missile);
        }
    }
}