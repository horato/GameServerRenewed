using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities
{
    public interface IMap
    {
        MapType Id { get; }
    }
}
