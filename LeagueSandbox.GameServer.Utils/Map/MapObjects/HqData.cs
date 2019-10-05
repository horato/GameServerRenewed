using LeagueSandbox.GameServer.Core.Domain.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public class HqData
    {
        public uint NetId { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Team Team { get; }

        public float MaxHp { get; }
        public float BaseStaticHPRegen { get; }
        public float Armor { get; }
        public float MaxMP { get; }
        public float SelectionHeight { get; }
        public float SelectionRadius { get; }
        public float PerceptionBubbleRadius { get; }
        public string SkinName1 { get; }
        public string SkinName2 { get; }
        public float CollisionRadius { get; }
        public float CollisionHeight { get; }
        public float PathfindingCollisionRadius { get; }

        public HqData(uint netId, Team team, float maxHp, float baseStaticHpRegen, float armor, float maxMp, float selectionHeight, float selectionRadius, float perceptionBubbleRadius, string skinName1, string skinName2, float collisionRadius, float collisionHeight, float pathfindingCollisionRadius)
        {
            NetId = netId;
            Team = team;
            MaxHp = maxHp;
            BaseStaticHPRegen = baseStaticHpRegen;
            Armor = armor;
            MaxMP = maxMp;
            SelectionHeight = selectionHeight;
            SelectionRadius = selectionRadius;
            PerceptionBubbleRadius = perceptionBubbleRadius;
            SkinName1 = skinName1;
            SkinName2 = skinName2;
            CollisionRadius = collisionRadius;
            CollisionHeight = collisionHeight;
            PathfindingCollisionRadius = pathfindingCollisionRadius;
        }
    }
}
