using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Spells;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class LevelPropAI : ObjAiBase, ILevelPropAI
    {
        public Vector3 FacingDirection { get; }
        public Vector3 PositionOffset { get; }
        public Vector3 Scale { get; }
        public string Name { get; }

        public LevelPropAI(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId, float visionRadius, ISpellBook spellBook, float collisionRadius, Vector3 facingDirection, Vector3 positionOffset, Vector3 scale, string name, bool isMelee, float autoAttackCastTime) : base(team, position, stats, netId, visionRadius, collisionRadius, skinName, skinId, spellBook, isMelee, autoAttackCastTime)
        {
            FacingDirection = facingDirection;
            PositionOffset = positionOffset;
            Scale = scale;
            Name = name;
        }
    }
}
