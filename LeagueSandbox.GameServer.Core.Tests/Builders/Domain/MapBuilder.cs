using System.Collections.Generic;
using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain
{
    internal class MapBuilder : EntityBuilderBase<Map>
    {
        private MapType _id = MapType.CrystalScar;
        private IDictionary<int, float> _expCurveDictionary = new Dictionary<int, float>();
        private IMapScript _mapScript;

        public MapBuilder WithId(MapType id)
        {
            _id = id;
            return this;
        }

        public MapBuilder WithExpCurveDictionary(IDictionary<int, float> expCurveDictionary)
        {
            _expCurveDictionary = expCurveDictionary;
            return this;
        }

        public MapBuilder WithMapScript(IMapScript mapScript)
        {
            _mapScript = mapScript;
            return this;
        }

        public override Map Build()
        {
            var instance = new Map(_id, _expCurveDictionary, _mapScript);

            return instance;
        }
    }
}
