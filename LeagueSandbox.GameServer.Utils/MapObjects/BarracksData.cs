namespace LeagueSandbox.GameServer.Utils.MapObjects
{
    public class BarracksData
    {
        public float MaxHP { get; }
        public float BaseStaticHPRegen { get; }
        public float Armor { get; }
        public float MaxMP { get; }
        public float SelectionHeight { get; }
        public float SelectionRadius { get; }
        public float PerceptionBubbleRadius { get; }
        public string SkinName1 { get; }
        public string SkinName2 { get; }
        public float PathfindingCollisionRadius { get; }

        public BarracksData(float maxHp, float baseStaticHpRegen, float armor, float maxMp, float selectionHeight, float selectionRadius, float perceptionBubbleRadius, string skinName1, string skinName2, float pathfindingCollisionRadius)
        {
            MaxHP = maxHp;
            BaseStaticHPRegen = baseStaticHpRegen;
            Armor = armor;
            MaxMP = maxMp;
            SelectionHeight = selectionHeight;
            SelectionRadius = selectionRadius;
            PerceptionBubbleRadius = perceptionBubbleRadius;
            SkinName1 = skinName1;
            SkinName2 = skinName2;
            PathfindingCollisionRadius = pathfindingCollisionRadius;
        }
    }
}
