using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Utils.Map.MapObjects
{
    public interface IBarrackSpawnData
    {
        Lane Lane { get; }
        Team Team { get; }
    }
}