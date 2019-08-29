using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal interface IStatFactory
    {
        IStat CreateEmpty();
        IStat CreateNew(float baseValue, float baseBonus, float percentBaseBonus, float flatBonus, float percentBonus);
    }
}