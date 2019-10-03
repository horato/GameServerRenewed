using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Lib.Providers;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using Unity;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Spells
{
    internal class SpellBookFactory : EntityFactoryBase<SpellBook>, ISpellBookFactory
    {
        private readonly ISpellFactory _spellFactory;
        private readonly ISpellDataProvider _spellDataProvider;

        public SpellBookFactory(IUnityContainer unityContainer, ISpellFactory spellFactory, ISpellDataProvider spellDataProvider) : base(unityContainer)
        {
            _spellFactory = spellFactory;
            _spellDataProvider = spellDataProvider;
        }

        public ISpellBook CreateEmpty()
        {
            var instance = new SpellBook(null, 0, new List<ISpell>(), new Dictionary<ExtraSpellNumber, string>());

            return SetupDependencies(instance);
        }

        public ISpellBook CreateFromCharacterData(string characterName, CharacterData data)
        {
            var spells = new List<ISpell>();
            if (!string.IsNullOrWhiteSpace(data.Spell1))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell1);
                var maxLevel = data.MaxLevels[0];
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.Q, data.Spell1, maxLevel, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.Spell2))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell2);
                var maxLevel = data.MaxLevels[1];
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.W, data.Spell2, maxLevel, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.Spell3))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell3);
                var maxLevel = data.MaxLevels[2];
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.E, data.Spell3, maxLevel, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.Spell4))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell4);
                var maxLevel = data.MaxLevels[3];
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.R, data.Spell4, maxLevel, spellData);
                spells.Add(spell);
            }

            var extraSpells = CreateExtraSpellsDictionary(data);
            var instance = new SpellBook(null, 1, spells, extraSpells);
            return SetupDependencies(instance);
        }

        private IDictionary<ExtraSpellNumber, string> CreateExtraSpellsDictionary(CharacterData data)
        {
            var result = new Dictionary<ExtraSpellNumber, string>();
            if (!string.IsNullOrWhiteSpace(data.ExtraSpell1))
            {
                result.Add(ExtraSpellNumber.Spell1, data.ExtraSpell1);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell2))
            {
                result.Add(ExtraSpellNumber.Spell2, data.ExtraSpell2);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell3))
            {
                result.Add(ExtraSpellNumber.Spell3, data.ExtraSpell3);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell4))
            {
                result.Add(ExtraSpellNumber.Spell4, data.ExtraSpell4);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell5))
            {
                result.Add(ExtraSpellNumber.Spell5, data.ExtraSpell5);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell6))
            {
                result.Add(ExtraSpellNumber.Spell6, data.ExtraSpell6);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell7))
            {
                result.Add(ExtraSpellNumber.Spell7, data.ExtraSpell7);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell8))
            {
                result.Add(ExtraSpellNumber.Spell8, data.ExtraSpell8);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell9))
            {
                result.Add(ExtraSpellNumber.Spell9, data.ExtraSpell9);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell10))
            {
                result.Add(ExtraSpellNumber.Spell10, data.ExtraSpell10);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell11))
            {
                result.Add(ExtraSpellNumber.Spell11, data.ExtraSpell11);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell12))
            {
                result.Add(ExtraSpellNumber.Spell12, data.ExtraSpell12);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell13))
            {
                result.Add(ExtraSpellNumber.Spell13, data.ExtraSpell13);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell14))
            {
                result.Add(ExtraSpellNumber.Spell14, data.ExtraSpell14);
            }

            return result;
        }
    }
}
