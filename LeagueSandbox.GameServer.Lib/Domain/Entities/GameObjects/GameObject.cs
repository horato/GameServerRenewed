using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal abstract class GameObject : IGameObject
    {
        public Team Team { get; }
        public Vector3 Position { get; private set; }
        public float VisionRadius { get; }
        public bool IsPositionChanged { get; private set; }
        public uint NetId { get; }

        protected GameObject(Team team, Vector3 position, float visionRadius, uint netId)
        {
            Team = team;
            Position = position;
            VisionRadius = visionRadius;
            NetId = netId;
        }

        public void SetPosition(Vector3 position)
        {
            if (Position == position)
                return;

            Position = position;
            IsPositionChanged = true;
        }

        public void OnMovementDataSent()
        {
            if (!IsPositionChanged)
                return;

            IsPositionChanged = false;
        }
    }
}
