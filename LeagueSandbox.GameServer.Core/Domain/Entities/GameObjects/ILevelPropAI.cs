using System.Numerics;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface ILevelPropAI : IObjAiBase
    {
        Vector3 FacingDirection { get; }
        Vector3 PositionOffset { get; }
        string Name { get; }
    }
}