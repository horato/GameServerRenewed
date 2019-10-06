using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Map.MapObjects
{
    public interface IShopData
    {
        Team Team { get; }
        uint NetId { get; }
    }
}