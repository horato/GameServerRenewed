﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;

namespace LeagueSandbox.GameServer.Utils.MapObjects
{
    public static class MapObjectsReader
    {
        public static IEnumerable<MapObject> ReadMapObjects(MapType mapId)
        {
            var filePath = $"Data/Maps/{MapIdHelper.TranslateMapId(mapId)}/MapObjects.json";
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<IEnumerable<MapObject>>(json);
        }
    }
}
