using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface IBarracksData
    {
        string Name { get; }
        uint NetId { get; }
        Lane Lane { get; }
        Team Team { get; }
        float MaxHP { get; }
        float BaseStaticHPRegen { get; }
        float Armor { get; }
        float MaxMP { get; }
        float SelectionHeight { get; }
        float SelectionRadius { get; }
        float PerceptionBubbleRadius { get; }
        string SkinName1 { get; }
        string SkinName2 { get; }
        float PathfindingCollisionRadius { get; }
    }
}