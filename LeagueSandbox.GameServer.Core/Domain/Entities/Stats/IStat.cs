namespace LeagueSandbox.GameServer.Core.Domain.Entities.Stats
{
    public interface IStat
    {
        float BaseBonus { get; }
        float FlatBonus { get; }
        float BaseValue { get; }
        float PercentBonus { get; }
        float PercentBaseBonus { get; }
        float Total { get; }
        bool ApplyStatModifier(IStatModifier statModifier);
        bool RemoveStatModifier(IStatModifier statModifier);
    }
}