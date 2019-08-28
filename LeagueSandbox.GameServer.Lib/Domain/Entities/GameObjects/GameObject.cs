using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Lib.Domain.Entities.GameObjects
{
    internal abstract class GameObject : IGameObject
    {
        public Team Team { get; }
        public Vector3 Position { get; }

        public GameObject(Team team, Vector3 position)
        {
            Team = team;
            Position = position;
        }
    }
}
