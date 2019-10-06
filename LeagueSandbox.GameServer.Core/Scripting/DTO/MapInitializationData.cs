using System;
using System.Collections.Generic;
using System.Text;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Scripting.DTO
{
    public class MapInitializationData
    {
        public IDictionary<int, float> ExpCurve { get; }
        public IEnumerable<IGameObject> InitialGameObjects { get; }
        public MapType MapType { get; }
        public IMapScript MapScript { get; }

        public MapInitializationData(IDictionary<int, float> expCurve, IEnumerable<IGameObject> initialGameObjects, MapType mapType, IMapScript mapScript)
        {
            ExpCurve = expCurve;
            InitialGameObjects = initialGameObjects;
            MapType = mapType;
            MapScript = mapScript;
        }
    }
}
