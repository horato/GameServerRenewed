using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace LeagueSandbox.GameServer.Utils.CharacterDatas
{
    public static class CharacterDataReader
    {
        public static CharacterData ReadData(string characterName)
        {
            var filePath = $"Data/Characters/{characterName}/{characterName}.json";
            var json = File.ReadAllText(filePath);
            var token = (JToken)JsonConvert.DeserializeObject(json);
            if (token?["Values"]?["Data"] == null)
                return null;

            return new JsonSerializer().Deserialize<CharacterData>(token["Values"]["Data"].CreateReader());
        }

        public static IDictionary<string, CharacterData> ReadAll()
        {
            var result = new Dictionary<string, CharacterData>();
            var charNames = Directory.EnumerateDirectories("Data/Characters/").Select(x => x.Split('/').Last());
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
