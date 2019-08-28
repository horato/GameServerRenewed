using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Lib.Domain.Entities;
using LeagueSandbox.GameServer.Lib.Tests.Base;

namespace LeagueSandbox.GameServer.Lib.Tests.Builders.Domain
{
    internal class MapBuilder : EntityBuilderBase<Map>
    {
        private MapType _id = MapType.ProvingGrounds;

        public MapBuilder WithId(MapType id)
        {
            _id = id;
            return this;
        }

        public override Map Build()
        {
            var instance = new Map(_id);

            return instance;
        }
    }
}
