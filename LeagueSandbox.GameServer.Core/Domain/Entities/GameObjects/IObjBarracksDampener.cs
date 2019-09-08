using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjBarracksDampener : IObjAnimatedBuilding
    {
        Lane Lane { get; }
    }
}