using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Utils.CharacterDatas;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal class SpellDataProvider : ISpellDataProvider
    {
        private readonly IDictionary<string, IDictionary<string, SpellData>> _characterSpellDataCache;

        public SpellDataProvider()
        {
            _characterSpellDataCache = SpellDataReader.ReadAll();
        }

        public SpellData ProvideCharacterSpellData(string characterName, string spellName)
        {
            if (!_characterSpellDataCache.ContainsKey(characterName))
                throw new InvalidOperationException($"Character {characterName} not found");
            if(!_characterSpellDataCache[characterName].ContainsKey(spellName))
                throw new InvalidOperationException($"Spell {spellName} not found for character {characterName}");

            return _characterSpellDataCache[characterName][spellName];
        }
    }
}
