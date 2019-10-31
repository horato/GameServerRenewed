using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal class SpellDataProvider : ISpellDataProvider
    {
        private readonly IDictionary<string, IDictionary<string, ISpellData>> _characterSpellDataCache;

        public SpellDataProvider()
        {
            _characterSpellDataCache = SpellDataReader.ReadAll();
        }

        public ISpellData ProvideCharacterSpellData(string characterName, string spellName)
        {
            if (TryFindSpellDataInCharacterPackage(characterName, spellName, out var data))
                return data;
            if (TryFindSpellDataInGlobalPackage(spellName, out var globalData))
                return globalData;

            throw new InvalidOperationException($"Data for spell {spellName} of character {characterName} not found");
        }

        private bool TryFindSpellDataInCharacterPackage(string characterName, string spellName, out ISpellData spellData)
        {
            spellData = null;
            if (!_characterSpellDataCache.ContainsKey(characterName))
                return false;
            if (!_characterSpellDataCache[characterName].ContainsKey(spellName))
                return false;

            spellData = _characterSpellDataCache[characterName][spellName];
            return true;
        }

        private bool TryFindSpellDataInGlobalPackage(string spellName, out ISpellData spellData)
        {
            spellData = null;
            if (!_characterSpellDataCache.ContainsKey(SpellDataReader.GlobalPackage))
                return false;
            if (!_characterSpellDataCache[SpellDataReader.GlobalPackage].ContainsKey(spellName))
                return false;

            spellData = _characterSpellDataCache[SpellDataReader.GlobalPackage][spellName];
            return true;
        }

        public ISpellData ProvideSummonerSpellData(SummonerSpell spell)
        {
            return ProvideCharacterSpellData(SpellDataReader.GlobalPackage, spell.ToSpellName());
        }
    }
}
