using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Domain.Entities.GameObjects
{
    public interface IObjAiTurret : IObjAiBase
    {
        Lane Lane { get; }
        TurretPosition TurretPosition { get; }
    }
}