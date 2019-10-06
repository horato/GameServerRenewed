using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Map.MapObjects;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public class BarracksData : IBarracksData
    {
        public string Name { get; }
        public uint NetId { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Lane Lane { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Team Team { get; }

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

        public BarracksData(string name, uint netId, Lane lane, Team team, float maxHp, float baseStaticHpRegen, float armor, float maxMp, float selectionHeight, float selectionRadius, float perceptionBubbleRadius, string skinName1, string skinName2, float pathfindingCollisionRadius)
        {
            Name = name;
            NetId = netId;
            Lane = lane;
            Team = team;
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
