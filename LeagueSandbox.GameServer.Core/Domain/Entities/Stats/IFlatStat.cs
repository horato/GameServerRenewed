namespace LeagueSandbox.GameServer.Core.Domain.Entities.Stats
{
    public interface IFlatStat
    {
        bool IsUpdated { get; }
        float CurrentValue { get; }
        float BonusPerLevel { get; }
        float RegenerationPer5 { get; }
        float RegenerationBonusPerLevel { get; }

        bool ApplyStatModifier(IFlatStatModifier statModifier);
        bool RemoveStatModifier(IFlatStatModifier statModifier);
        void OnStatUpdateSent();
    }
}