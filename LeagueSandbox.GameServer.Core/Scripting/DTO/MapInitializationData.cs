using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Scripting.DTO
{
    public class MapInitializationData
    {
        public IDictionary<int, float> ExpCurve { get; }
        public MapType MapType { get; }
        public IMapScript MapScript { get; }

        public MapInitializationData(IDictionary<int, float> expCurve, MapType mapType, IMapScript mapScript)
        {
            ExpCurve = expCurve;
            MapType = mapType;
            MapScript = mapScript;
        }
    }
}
