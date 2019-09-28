using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public static class SpellDataReader
    {
        public static SpellData ReadData(string characterName, string spellName)
        {
            var filePath = $"Data/Characters/{characterName}/Spells/{spellName}.json";
            var json = File.ReadAllText(filePath);
            var token = (JToken)JsonConvert.DeserializeObject(json);
            if (token?["Values"]?["SpellData"] == null)
                return null;

            return new JsonSerializer().Deserialize<SpellData>(token["Values"]["SpellData"].CreateReader());
        }

        /// <summary> CharName-SpellName-Spell </summary>
        public static IDictionary<string, IDictionary<string, SpellData>> ReadAll()
        {
            var result = new Dictionary<string, IDictionary<string, SpellData>>();
            var charNames = Directory.EnumerateDirectories("Data/Characters/").Select(Path.GetFileNameWithoutExtension);

            foreach (var charName in charNames)
            {
                if (!result.ContainsKey(charName))
                    result.Add(charName, new Dictionary<string, SpellData>());

                var charSpells = result[charName];
                if (!Directory.Exists($"Data/Characters/{charName}/Spells"))
                    continue;

                var spellNames = Directory.EnumerateFiles($"Data/Characters/{charName}/Spells", "*.json").Select(Path.GetFileNameWithoutExtension);
                foreach (var spellName in spellNames)
                {
                    var data = ReadData(charName, spellName);
                    if (data == null)
                        continue;

                    charSpells.Add(spellName, data);
                }
            }

            return result;
        }
    }
}
