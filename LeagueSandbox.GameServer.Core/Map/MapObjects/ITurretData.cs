using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface ITurretData
    {
        string SkinName { get; }
        string CharacterName { get; }
        Team Team { get; }
        TurretPosition Position { get; }
        Lane Lane { get; }
    }
}