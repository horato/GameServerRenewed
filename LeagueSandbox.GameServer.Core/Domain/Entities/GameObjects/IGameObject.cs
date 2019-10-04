using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IGameObject
    {
        Team Team { get; }
        Vector3 Position { get; }
        float VisionRadius { get; }
        float CollisionRadius { get; }
        bool IsPositionChanged { get; }
        uint NetId { get; }

        void SetPosition(Vector3 position);
        void OnMovementDataSent();
    }
}