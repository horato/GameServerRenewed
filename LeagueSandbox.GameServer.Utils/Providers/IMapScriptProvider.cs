using LeagueSandbox.GameServer.Core.Domain.Enums;
using LeagueSandbox.GameServer.Core.Scripting;

namespace LeagueSandbox.GameServer.Utils.Providers
{
    public interface IMapScriptProvider
    {
        IMapScript ProvideMapScript(MapType map);
    }
}