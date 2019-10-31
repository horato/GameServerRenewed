using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LeagueSandbox.GameServer.Core.Data;
using Newtonsoft.Json.Linq;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public static class CharacterDataReader
    {
        public static ICharacterData ReadData(string characterName)
        {
            var filePath = $"Data/Characters/{characterName}/{characterName}.json";
            var json = File.ReadAllText(filePath);
            var token = (JToken)JsonConvert.DeserializeObject(json);
            if (token?["Values"]?["Data"] == null)
                return null;

            return new JsonSerializer().Deserialize<CharacterData>(token["Values"]["Data"].CreateReader());
        }

        public static IDictionary<string, ICharacterData> ReadAll()
        {
            var result = new Dictionary<string, ICharacterData>();
            var charNames = Directory.EnumerateDirectories("Data/Characters/").Select(Path.GetFileNameWithoutExtension);
            foreach (var charName in charNames)
            {
                var data = ReadData(charName);
                if (data == null)
                    continue;

                result.Add(charName, data);
            }

            return result;
        }
    }
}
