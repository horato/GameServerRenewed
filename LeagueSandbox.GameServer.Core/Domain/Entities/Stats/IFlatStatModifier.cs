namespace LeagueSandbox.GameServer.Core.Domain.Entities.Stats
{
    public interface IFlatStatModifier
    {
        float Value { get; }
        float BonusPerLevel { get; }
        float RegenerationPer5 { get; }
        bool StatModified { get; }
        float RegenerationBonusPerLevel { get; }
    }
}