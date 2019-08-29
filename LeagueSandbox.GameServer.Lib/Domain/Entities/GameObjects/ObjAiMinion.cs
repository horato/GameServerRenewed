using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjAiMinion : ObjAiBase, IObjAiMinion
    {
        //MinionRoamState
        //    CampNumber
        //LeashCounter
        //    LeashedPos
        //LeashedOrientation
        //    GroupPos
        //BarrackSpawn
        //    MinionFlags
        //IsWard
        //    IsLaneMinion

        public ObjAiMinion(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId) : base(team, position, stats, netId, skinName, skinId)
        {
        }
    }
}
