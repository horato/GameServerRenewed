using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface INavPointData
    {
        Lane Lane { get; }
        int Order { get; }
    }
}