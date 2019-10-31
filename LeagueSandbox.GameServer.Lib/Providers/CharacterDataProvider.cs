using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using LeagueSandbox.GameServer.Utils.CharacterDatas;
using LeagueSandbox.GameServer.Utils.Providers;

namespace LeagueSandbox.GameServer.Lib.Providers
{
    internal class CharacterDataProvider : ICharacterDataProvider
    {
        private readonly IDictionary<string, ICharacterData> _characterDataCache;

        public CharacterDataProvider()
        {
            _characterDataCache = CharacterDataReader.ReadAll();
        }

        public ICharacterData ProvideCharacterData(string characterName)
        {
            if (!_characterDataCache.ContainsKey(characterName))
                throw new InvalidOperationException($"Character {characterName} not found");

            return _characterDataCache[characterName];
        }
    }
}
