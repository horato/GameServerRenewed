using System.Numerics;
using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IGameObject
    {
        Team Team { get; }
        Vector3 Position { get; }
    }
}