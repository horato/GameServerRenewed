using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;

namespace LeagueSandbox.GameServer.Lib.Domain.Factories.Stats
{
    internal interface IFlatStatFactory
    {
        IFlatStat CreateEmpty();
        IFlatStat CreateNew(float currentValue, float bonusPerLevel, float regenerationPer5);
    }
}