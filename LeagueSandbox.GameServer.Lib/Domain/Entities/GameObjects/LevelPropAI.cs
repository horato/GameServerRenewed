using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class LevelPropAI : ObjAiBase, ILevelPropAI
    {
        public Vector3 FacingDirection { get; }
        public Vector3 PositionOffset { get; }
        public string Name { get; }

        public LevelPropAI(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId, float visionRadius, Vector3 facingDirection, Vector3 positionOffset, string name) : base(team, position, stats, netId, skinName, skinId, visionRadius)
        {
            FacingDirection = facingDirection;
            PositionOffset = positionOffset;
            Name = name;
        }
    }
}
