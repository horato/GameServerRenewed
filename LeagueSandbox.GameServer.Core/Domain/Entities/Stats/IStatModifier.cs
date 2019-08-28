namespace LeagueSandbox.GameServer.Core.Domain.Entities.Stats
{
    public interface IStatModifier
    {
        float BaseBonus { get; }
        float PercentBaseBonus { get; }
        float FlatBonus { get; }
        float PercentBonus { get; }
        bool StatModified { get; }
    }
}