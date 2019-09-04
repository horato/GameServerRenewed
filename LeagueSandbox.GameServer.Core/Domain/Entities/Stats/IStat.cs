namespace LeagueSandbox.GameServer.Core.Domain.Entities.Stats
{
    public interface IStat
    {
        bool IsUpdated { get; }
        float BaseBonus { get; }
        float FlatBonus { get; }
        float BaseValue { get; }
        float PercentBonus { get; }
        float PercentBaseBonus { get; }
        float Total { get; }
        bool ApplyStatModifier(IStatModifier statModifier);
        bool RemoveStatModifier(IStatModifier statModifier);
        void OnStatUpdateSent();
    }
}