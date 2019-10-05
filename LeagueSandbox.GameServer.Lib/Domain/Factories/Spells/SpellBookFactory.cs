using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Domain.Factories;
using LeagueSandbox.GameServer.Lib.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using LeagueSandbox.GameServer.Utils.Providers;
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
            var instance = new SpellBook(null, 0, new List<ISpell>());

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

            AddExtraSpells(characterName, data, spells);
            var instance = new SpellBook(null, 1, spells);
            return SetupDependencies(instance);
        }

        private void AddExtraSpells(string characterName, CharacterData data, IList<ISpell> spells)
        {
            if (!string.IsNullOrWhiteSpace(data.ExtraSpell1))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell1);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell1, data.ExtraSpell1, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell2))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell2);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell2, data.ExtraSpell2, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell3))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell3);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell3, data.ExtraSpell3, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell4))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell4);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell4, data.ExtraSpell4, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell5))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell5);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell5, data.ExtraSpell5, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell6))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell6);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell6, data.ExtraSpell6, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell7))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell7);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell7, data.ExtraSpell7, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell8))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell8);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell8, data.ExtraSpell8, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell9))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell9);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell9, data.ExtraSpell9, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell10))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell10);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell10, data.ExtraSpell10, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell11))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell11);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell11, data.ExtraSpell11, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell12))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell12);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell12, data.ExtraSpell12, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell13))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell13);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell13, data.ExtraSpell13, 0, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.ExtraSpell14))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.ExtraSpell14);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.ExtraSpell14, data.ExtraSpell14, 0, spellData);
                spells.Add(spell);
            }
        }
    }
}
