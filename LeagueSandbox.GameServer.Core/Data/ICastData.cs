using LeagueSandbox.GameServer.Core.Domain.Enums;

namespace LeagueSandbox.GameServer.Core.Data
{
    public interface ICastData
    {
        CastType CastType { get; }
    }
}