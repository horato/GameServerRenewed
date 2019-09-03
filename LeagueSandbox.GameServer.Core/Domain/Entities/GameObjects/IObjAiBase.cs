using System.Collections.Generic;
using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiBase : IAttackableUnit
    {
        string SkinName { get; }
        int SkinId { get; }
        IEnumerable<Vector2> Waypoints { get; }
        bool IsMoving { get; }

        void Move(IEnumerable<Vector2> waypoints, MovementType movementType);
        void StopMovement();
        void DoEmote();
        void OnMovementPointReached(Vector2 point);
    }
}