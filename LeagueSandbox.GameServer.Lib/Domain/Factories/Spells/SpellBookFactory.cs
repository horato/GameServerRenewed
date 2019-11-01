using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
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

        public ISpellBook CreateFromCharacterData(string characterName, ICharacterData data)
        {
            var spells = new List<ISpell>();

            foreach (var spell in data.Spells)
            {
                var baseSpellData = spell.Value;
                if (string.IsNullOrEmpty(baseSpellData.Name))
                    continue; // TODO: Is this ok? Shouldn't spell jsons already be cleared of empty values?

                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, baseSpellData.Name);
                var domainSpell = _spellFactory.CreateFromSpellData(spell.Key, baseSpellData, spellData);
                spells.Add(domainSpell);
            }

            foreach (var spell in data.ExtraSpells)
            {
                var spellName = spell.Value;
                if (string.IsNullOrWhiteSpace(spellName))
                    continue; // TODO: Is this ok? Shouldn't spell jsons already be cleared of empty values?

                var baseSpellData = new BaseSpellData(spellName, 1, new List<int>()); //TODO: ??
                var spellData = _spellDataProvider.ProvideCharacterSpellData(characterName, baseSpellData.Name);
                var domainSpell = _spellFactory.CreateFromSpellData(spell.Key, baseSpellData, spellData);
                spells.Add(domainSpell);
            }

            var instance = new SpellBook(null, 1, spells);
            return SetupDependencies(instance);
        }
    }
}
