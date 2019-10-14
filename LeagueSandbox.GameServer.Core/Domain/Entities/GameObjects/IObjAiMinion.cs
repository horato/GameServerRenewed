using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiMinion : IObjAiBase
    {
        MinionActionState MinionState { get; }
        IDictionary<int, Vector2> MinionWaypoints { get; }
        int CurrentWaypoint { get; }
        int MaxWaypoint { get; }
        bool IsLaneMinion { get; }

        void SpawnCompleted();
        void WaypointReached();
        bool HasMoreWaypoints();
        void DestinationReached();
    }
}