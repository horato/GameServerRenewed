using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal abstract class ObjAiBase : AttackableUnit, IObjAiBase
    {
        public string SkinName { get; }
        public int SkinId { get; }

        //ExpGiveRadius
        //GoldGiveRadius
        //Spellbook
        //    SpellBuffs
        //DeathTimer
        //VisionRegion
        protected ObjAiBase(Team team, Vector3 position, IStats stats, uint netId) : base(team, position, stats, netId)
        {

        }
    }
}
