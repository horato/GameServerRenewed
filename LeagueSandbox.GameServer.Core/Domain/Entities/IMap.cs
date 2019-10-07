using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;

namespace LeagueSandbox.GameServer.Core.Domain.Entities
{
    public interface IMap
    {
        MapType Id { get; }
        int MaxLevel { get; }
        float MaxExp { get; }
        IMapScript MapScript { get; }

        float GetExpNeededForLevel(int level);
        int GetLevelFromExp(float exp);
    }
}
