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
            var instance = new SpellBook(null, new List<ISpell>());

            return SetupDependencies(instance);
        }

        public ISpellBook CreateFromCharacterData(string characterName, CharacterData data)
        {
            var spells = new List<ISpell>();
            if (!string.IsNullOrWhiteSpace(data.Spell1))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell1);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.Q, data.Spell1, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.Spell2))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell2);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.W, data.Spell2, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.Spell3))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell3);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.E, data.Spell3, spellData);
                spells.Add(spell);
            }

            if (!string.IsNullOrWhiteSpace(data.Spell4))
            {
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, data.Spell4);
                var spell = _spellFactory.CreateFromSpellData(SpellSlot.R, data.Spell4, spellData);
                spells.Add(spell);
            }

            var instance = new SpellBook(null, spells);
            return SetupDependencies(instance);
        }
    }
}
