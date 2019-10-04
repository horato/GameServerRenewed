using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal class NeutralMinionCamp : GameObject, INeutralMinionCamp
    {
        //CampPosition
        //CampIcon
        //MinionIDs
        //CampIndex
        //KnownToBeActive
        //SpawnEndTime
        //SpawnFinished
        public NeutralMinionCamp(Team team, Vector3 position, uint netId, float collisionRadius) : base(team, position, 0, collisionRadius, netId)
        {

        }
    }
}
