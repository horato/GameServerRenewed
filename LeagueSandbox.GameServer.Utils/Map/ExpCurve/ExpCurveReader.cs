using System;
using System.Collections.Generic;
using System.IO;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeagueSandbox.GameServer.Utils.Map.ExpCurve
{
    public static class ExpCurveReader
    {
        public static ExpCurve ReadExpCurve(MapType mapId)
        {
            var filePath = $"Data/Maps/{MapIdHelper.TranslateMapId(mapId)}/ExpCurve.json";
            var json = File.ReadAllText(filePath);
            var token = (JToken)JsonConvert.DeserializeObject(json);
            if (token?["Values"]?["EXP"] == null)
                throw new InvalidOperationException("Failed to load exp curve");

            return new JsonSerializer().Deserialize<ExpCurve>(token["Values"]["EXP"].CreateReader());
        }
    }
}
