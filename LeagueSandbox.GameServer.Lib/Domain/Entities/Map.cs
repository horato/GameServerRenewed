using LeagueSandbox.GameServer.Core.Domain.Entities;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities
{
    internal class Map : IMap
    {
        public MapType Id { get; }

        public Map(MapType id)
        {
            Id = id;
        }
    }
}
