using System;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Services.Update
{
    internal class ObjAiMinionUpdateService : IObjAiMinionUpdateService
    {
        public void Update(IObjAiMinion minion, float millisecondsDiff)
        {
            switch (minion.MinionState)
            {
                case MinionActionState.Spawned:
                    CompleteSpawn(minion);
                    break;
                case MinionActionState.Moving:
                    Move(minion);
                    break;
                case MinionActionState.Attacking:
                    break;
                case MinionActionState.DestinationReached:
                    break; // Nothing to do
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CompleteSpawn(IObjAiMinion minion)
        {
            minion.SpawnCompleted();
            MoveToNextWaypoint(minion);
        }

        private void Move(IObjAiMinion minion)
        {
            // TODO: attack
            if (minion.IsMoving)
                return;

            minion.WaypointReached();
            MoveToNextWaypoint(minion);
        }

        private void MoveToNextWaypoint(IObjAiMinion minion)
        {
            if (!minion.HasMoreWaypoints())
            {
                minion.DestinationReached();
                return;
            }

            var position = minion.MinionWaypoints[minion.CurrentWaypoint];
            minion.Move(new[] { position }, MovementType.Move);
        }
    }
}