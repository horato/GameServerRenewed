using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Services
{
    public interface IPathingService
    {
        void Initialize(MapType mapId);
    }
}