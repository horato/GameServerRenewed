using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities
{
    public interface IMap
    {
        MapType Id { get; }
        int MaxLevel { get; }
        float MaxExp { get; }

        float GetExpNeededForLevel(int level);
        int GetLevelFromExp(float exp);
    }
}
