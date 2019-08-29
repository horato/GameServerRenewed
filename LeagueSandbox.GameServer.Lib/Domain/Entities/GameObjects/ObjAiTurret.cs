using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Entities.Stats;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class ObjAiTurret : ObjAiBase, IObjAiTurret
    {
        //SwapModelOnDeathTime
        //    SwapModelOnDeathTime
        public ObjAiTurret(Team team, Vector3 position, IStats stats, uint netId, string skinName, int skinId) : base(team, position, stats, netId, skinName, skinId)
        {
        }
    }
}
