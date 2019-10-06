using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface IHqData
    {
        uint NetId { get; }
        Team Team { get; }
        float MaxHp { get; }
        float BaseStaticHPRegen { get; }
        float Armor { get; }
        float MaxMP { get; }
        float SelectionHeight { get; }
        float SelectionRadius { get; }
        float PerceptionBubbleRadius { get; }
        string SkinName1 { get; }
        string SkinName2 { get; }
        float CollisionRadius { get; }
        float CollisionHeight { get; }
        float PathfindingCollisionRadius { get; }
    }
}